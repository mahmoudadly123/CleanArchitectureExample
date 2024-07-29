using CleanArchitecture.Application.ObjectMapping.AutoMapper.Dtos.OrderItem;
using CleanArchitecture.Application.Validation.FluentValidation.Abstract;
using FluentValidation;

namespace CleanArchitecture.Application.Validation.FluentValidation.Validators.OrderItem
{
    public class CreateOrderItemDtoValidator : BaseValidator<CreateOrderItemDto>
    {
        public CreateOrderItemDtoValidator()
        {
            RuleFor(p => p.Description)
                .NotEmpty().WithMessage("{PropertyName} is Required");

            RuleFor(p => p.UnitPrice)
                .NotEmpty().WithMessage("{PropertyName} is Required")
                .GreaterThan(0).WithMessage("{PropertyName} Must Be Greater than Zero");

            RuleFor(p => p.Quantity)
                .NotEmpty().WithMessage("{PropertyName} is Required")
                .GreaterThan(0).WithMessage("{PropertyName} Must Be Greater than Zero");

            
        }
    }
}
