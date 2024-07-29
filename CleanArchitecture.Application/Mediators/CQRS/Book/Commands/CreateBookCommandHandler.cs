using AutoMapper;
using CleanArchitecture.Application.Interfaces.Persistence.Abstract;
using CleanArchitecture.Application.Interfaces.Persistence.Repositories;
using CleanArchitecture.Application.Mediators.Abstract;
using CleanArchitecture.Application.ObjectMapping.AutoMapper.Dtos.Book;
using CleanArchitecture.Application.Validation.FluentValidation.Validators.Book;
using CleanArchitecture.Common.Results;

namespace CleanArchitecture.Application.Mediators.CQRS.Book.Commands
{
    public class CreateBookCommandHandler : CommandHandler<CreateBookCommand, CreateBookResponse>
    {
        private readonly IBookRepository _bookRepository;
        

        public CreateBookCommandHandler(IBookRepository bookRepository,IUnitOfWork unitOfWork ,IMapper mapper, INotificationPublisher notificationPublisher) : base(unitOfWork,mapper, notificationPublisher)
        {
            _bookRepository = bookRepository;
        }
        
        
        public override async Task<Result<CreateBookResponse>> Handle(CreateBookCommand request, CancellationToken cancellationToken)
        {
            try
            {
                //Validate Dto 
                var validator = await new CreateBookDtoValidator().ValidateAsync(request.CreateBookDto, cancellationToken);

                if (validator.IsValid == false)
                {
                    return Result.Failure<CreateBookResponse>(validator.Errors);
                }

                //Create Book using Entity
                var createBookDto = request.CreateBookDto;
                
                var newBookEntity = Domain.Entities.Book.Create(createBookDto.Title, createBookDto.Description, createBookDto.Category, createBookDto.IsActive);

                //Save Entity inside Database using Repository
                await _bookRepository.AddAsync(newBookEntity);

                
                //Save Changes using Unit of Work Pattern
                await UnitOfWork.SaveChangesAsync(cancellationToken);


                //Publish All Notifications to its Handlers
                await NotificationPublisher.PublishNotificationsAsync(newBookEntity.Notifications, cancellationToken);

                //Convert Entity To Dto
                var bookDto = AutoMapper.Map<ViewBookDto>(newBookEntity);

                var response = new CreateBookResponse(bookDto);

                return Result.Success(response);
            }
            catch (Exception e)
            {
                return Result.Failure<CreateBookResponse>(e);
            }
        }
        
       
    }
}
