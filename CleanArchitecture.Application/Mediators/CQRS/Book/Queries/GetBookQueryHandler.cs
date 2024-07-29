using AutoMapper;
using CleanArchitecture.Application.Interfaces.Persistence.Repositories;
using CleanArchitecture.Application.Mediators.Abstract;
using CleanArchitecture.Application.ObjectMapping.AutoMapper.Dtos.Book;
using CleanArchitecture.Common.Errors.Domain;
using CleanArchitecture.Common.Results;

namespace CleanArchitecture.Application.Mediators.CQRS.Book.Queries
{
    public class GetBookQueryHandler : QueryHandler<GetBookQuery, GetBookResponse>
    {
        private readonly IBookRepository _bookRepository;

        public GetBookQueryHandler(IBookRepository bookRepository, IMapper mapper) : base(mapper)
        {
            _bookRepository = bookRepository;
        }

        
        public override async Task<Result<GetBookResponse>> Handle(GetBookQuery request, CancellationToken cancellationToken)
        {
            try
            {
                //Get Data from Database using Repository as Entities
                var bookEntity = await _bookRepository.GetAsync(request.BookId);

                if (bookEntity is null)
                    return Result.Failure<GetBookResponse>(BookErrors.NotFound);

                //Convert Domain Entity to Dto using AutoMapper
                var bookDto = AutoMapper.Map<ViewBookDto>(bookEntity);

                var response = new GetBookResponse(bookDto);

                return Result.Success(response);
            }
            catch (Exception e)
            {
                return Result.Failure<GetBookResponse>(e);
            }
        }
        


    }
}
