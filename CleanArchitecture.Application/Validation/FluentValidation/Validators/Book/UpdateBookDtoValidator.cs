using CleanArchitecture.Application.ObjectMapping.AutoMapper.Dtos.Book;
using CleanArchitecture.Application.Validation.FluentValidation.Abstract;
using FluentValidation;

namespace CleanArchitecture.Application.Validation.FluentValidation.Validators.Book
{
    public class UpdateBookDtoValidator : BaseValidator<UpdateBookDto>
    {
        public UpdateBookDtoValidator()
        {
            //Rules for Name
            RuleFor(p => p.Title)
                .NotEmpty().WithMessage("{PropertyName} is Required")
                .MinimumLength(5).WithMessage("{PropertyName} at least 5 length")
                .MaximumLength(150).WithMessage("{PropertyName} length at max 150");

            //Rules for Role
            RuleFor(p => p.Category)
                .NotEmpty().WithMessage("{PropertyName} is Required");

        }
    }
}
