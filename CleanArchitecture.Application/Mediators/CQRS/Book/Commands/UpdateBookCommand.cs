using CleanArchitecture.Application.Mediators.Abstract;
using CleanArchitecture.Application.ObjectMapping.AutoMapper.Dtos.Book;


namespace CleanArchitecture.Application.Mediators.CQRS.Book.Commands
{
    public record UpdateBookCommand(int BookId,
                                    int UpdatedById,
                                    UpdateBookDto UpdatedBookDto) : ICommand<UpdateBookResponse>;
}
