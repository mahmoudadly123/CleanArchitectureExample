using CleanArchitecture.Application.Mediators.Abstract;

namespace CleanArchitecture.Application.Mediators.CQRS.Book.Queries
{
    public record GetBooksQuery : IQuery<GetBooksResponse>;
}
