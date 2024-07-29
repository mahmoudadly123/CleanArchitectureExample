using AutoMapper;
using CleanArchitecture.Application.Interfaces.Persistence.Abstract;
using CleanArchitecture.Application.Interfaces.Persistence.Repositories;
using CleanArchitecture.Application.Mediators.Abstract;
using CleanArchitecture.Application.Validation.FluentValidation.Validators.Book;
using CleanArchitecture.Common.Errors.Domain;
using CleanArchitecture.Common.Results;

namespace CleanArchitecture.Application.Mediators.CQRS.Book.Commands
{
    public class UpdateBookCommandHandler : CommandHandler<UpdateBookCommand,UpdateBookResponse>
    {
        private readonly IBookRepository _bookRepository;

        public UpdateBookCommandHandler(IBookRepository bookRepository,IUnitOfWork unitOfWork,IMapper mapper) : base(unitOfWork, mapper)
        {
            _bookRepository=bookRepository;
        }

        public override async Task<Result<UpdateBookResponse>> Handle(UpdateBookCommand request, CancellationToken cancellationToken)
        {
            try
            {
                //Validate Dto 
                var validator = await new UpdateBookDtoValidator().ValidateAsync(request.UpdatedBookDto, cancellationToken);

                if (validator.IsValid==false)
                {
                    return Result.Failure<UpdateBookResponse>(validator.Errors);
                }

                //check if original data exist or not
                var isExist = await _bookRepository.ExistAsync(request.BookId);
                if (isExist == false)
                {
                    return Result.Failure<UpdateBookResponse>($"Book with Id {request.BookId} Not Found");
                }

                //Get current Entity From Database via Repository
                var currentBookEntity = await _bookRepository.GetAsync(c => c.Id == request.BookId);

                if (currentBookEntity is null)
                {
                    return Result.Failure<UpdateBookResponse>(BookErrors.NotFound);
                }

                //Update Current Entity with New Updated Entity
                currentBookEntity.Update(request.UpdatedBookDto.Title,
                                         request.UpdatedBookDto.Description,
                                         request.UpdatedBookDto.Category,
                                         request.UpdatedBookDto.IsActive,
                                         request.UpdatedById);

                //Save Updated Entity inside database
                await _bookRepository.UpdateAsync(currentBookEntity);

                //Save Changes using Unit of Work Pattern
                await UnitOfWork.SaveChangesAsync(cancellationToken);

                var response = new UpdateBookResponse();

                return Result.Success(response);

            }
            catch (Exception e)
            {
                return Result.Failure<UpdateBookResponse>(e);
            }
        }
    }
}
