using CleanArchitecture.Application.ObjectMapping.AutoMapper.Dtos.Book;
using CleanArchitecture.Application.Validation.FluentValidation.Abstract;
using FluentValidation;

namespace CleanArchitecture.Application.Validation.FluentValidation.Validators.Book
{
    public class DeleteBookDtoValidator:BaseValidator<DeleteBookDto>
    {
        public DeleteBookDtoValidator()
        {
            RuleFor(p => p.Id)
                .NotNull().WithMessage("{PropertyName} is required")
                .NotEqual(0).WithMessage("{PropertyName} is required");
        }
    }
}
