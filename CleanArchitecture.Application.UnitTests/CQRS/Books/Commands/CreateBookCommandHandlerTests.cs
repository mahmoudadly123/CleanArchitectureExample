using Moq;
using AutoMapper;
using CleanArchitecture.Application.Interfaces.Persistence.Abstract;
using FluentAssertions;
using CleanArchitecture.Application.Interfaces.Persistence.Repositories;
using CleanArchitecture.Application.Mediators.Abstract;
using CleanArchitecture.Application.Mediators.CQRS.Book.Commands;
using CleanArchitecture.Application.ObjectMapping.AutoMapper.Dtos.Book;
using CleanArchitecture.Application.ObjectMapping.AutoMapper.Profiles;
using CleanArchitecture.Domain.Entities;


namespace CleanArchitecture.Application.UnitTests.CQRS.Books.Commands;


public class CreateBookCommandHandlerTests
{
    private readonly Mock<IUnitOfWork> _unitOfWorkMock;
    private readonly Mock<IBookRepository> _bookRepositoryMock;
    private readonly Mock<INotificationPublisher> _notificationPublisherMock;
    private readonly IMapper _mapper;

    public CreateBookCommandHandlerTests()
    {
        _unitOfWorkMock=new();
        _bookRepositoryMock = new();
        _notificationPublisherMock = new();
         

        //Setup AutoMapper
        _mapper = new MapperConfiguration(cfg =>
        {
            cfg.AddProfile<MappingProfile>();
        }).CreateMapper();

        

    }

    [Fact]
    public async Task Handle_Should_Return_FailureResult_When_Validation_Fail()
    {
        //Arrange

        var handler = new CreateBookCommandHandler(_bookRepositoryMock.Object, _unitOfWorkMock.Object, _mapper, _notificationPublisherMock.Object);

        //make validation fail
        var command = new CreateBookCommand(new CreateBookDto { Title = "", Category = "", IsActive = true });

        //Act
        var result =await handler.Handle(command, default);


        //Assert
        result.IsFailure.Should().BeTrue();
        result.HasErrors.Should().BeTrue();
        result.Errors.Should().NotBeEmpty();
        
    }

    [Fact]
    public async Task Handle_Should_Not_Return_FailureResult_When_Validation_Success()
    {
        //Arrange

        var handler = new CreateBookCommandHandler(_bookRepositoryMock.Object, _unitOfWorkMock.Object, _mapper, _notificationPublisherMock.Object);

        //make validation success
        var command = new CreateBookCommand(new CreateBookDto { Title = "Learning OOP", Category = "Programming", IsActive = true });

        //Act
        var result = await handler.Handle(command, default);
        

        //Assert
        result.IsFailure.Should().BeFalse();
        result.HasErrors.Should().BeFalse();
        result.Errors.Should().BeEmpty();
    }

    [Fact]
    public async Task Handle_Should_Return_SuccessResult_With_Value_When_Validation_Success()
    {
        //Arrange

        var newBookDto = new CreateBookDto { Title = "Learning OOP", Category = "Programming", IsActive = true };
        var newBookEntity = Book.Create(1, "Learning OOP","", "Programming", true);

        //Setup BookRepository Methods
        _bookRepositoryMock.Setup(x => x.AddAsync(newBookEntity, true)).ReturnsAsync(newBookEntity);

        var handler = new CreateBookCommandHandler(_bookRepositoryMock.Object, _unitOfWorkMock.Object, _mapper, _notificationPublisherMock.Object);

        var command = new CreateBookCommand(newBookDto);
        

        //Act
        var result = await handler.Handle(command, default);


        //Assert
        result.Value.Should().NotBeNull();

    }
}