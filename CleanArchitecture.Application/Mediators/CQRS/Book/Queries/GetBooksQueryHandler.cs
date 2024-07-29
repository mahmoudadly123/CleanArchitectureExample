using AutoMapper;
using CleanArchitecture.Application.Interfaces.Persistence.Repositories;
using CleanArchitecture.Application.Mediators.Abstract;
using CleanArchitecture.Application.ObjectMapping.AutoMapper.Dtos.Book;
using CleanArchitecture.Common.Results;

namespace CleanArchitecture.Application.Mediators.CQRS.Book.Queries
{
    public class GetBooksQueryHandler : QueryHandler<GetBooksQuery,GetBooksResponse>
    {
        private readonly IBookRepository _bookRepository;

        public GetBooksQueryHandler(IBookRepository bookRepository, IMapper mapper) : base(mapper)
        {
            _bookRepository = bookRepository;
        }

        
        public override async Task<Result<GetBooksResponse>> Handle(GetBooksQuery request, CancellationToken cancellationToken)
        {
            try
            {
                //Get Data from Database using Repository as Entities
                var booksEntities = await _bookRepository.GetAllAsync();
                
                //Convert Domain Entity to Dto using AutoMapper
                var booksDto = AutoMapper.Map<List<ViewBookDto>>(booksEntities);

                var response = new GetBooksResponse(booksDto);

                return Result.Success(response);
            }
            catch (Exception e)
            {
                return Result.Failure<GetBooksResponse>(e);
            }
        }


       
    }
}
