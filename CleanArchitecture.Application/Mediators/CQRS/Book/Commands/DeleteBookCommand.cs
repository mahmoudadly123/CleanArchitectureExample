using CleanArchitecture.Application.Mediators.Abstract;



namespace CleanArchitecture.Application.Mediators.CQRS.Book.Commands
{
    public record DeleteBookCommand(int BookId) : ICommand<DeleteBookResponse>;
}
