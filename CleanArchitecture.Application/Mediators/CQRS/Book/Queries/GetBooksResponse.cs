using CleanArchitecture.Application.ObjectMapping.AutoMapper.Dtos.Book;

namespace CleanArchitecture.Application.Mediators.CQRS.Book.Queries;

public record GetBooksResponse(List<ViewBookDto> ViewBooksDto);


