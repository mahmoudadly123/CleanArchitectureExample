using CleanArchitecture.Application.Mediators.Abstract;
using CleanArchitecture.Application.ObjectMapping.AutoMapper.Dtos.Book;

namespace CleanArchitecture.Application.Mediators.CQRS.Book.Commands
{
    public record CreateBookCommand(CreateBookDto CreateBookDto) : ICommand<CreateBookResponse>;
}
