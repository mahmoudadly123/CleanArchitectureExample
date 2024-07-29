using CleanArchitecture.Application.ObjectMapping.AutoMapper.Dtos.Order;
using CleanArchitecture.Application.Validation.FluentValidation.Abstract;
using FluentValidation;

namespace CleanArchitecture.Application.Validation.FluentValidation.Validators.Order
{
    public class CreateOrderDtoValidator : BaseValidator<CreateOrderDto>
    {
        public CreateOrderDtoValidator()
        {
            RuleFor(p => p.OrderNumber)
                .NotEmpty().WithMessage("{PropertyName} is Required")
                .MinimumLength(1).WithMessage("{PropertyName} at least 1 length")
                .MaximumLength(150).WithMessage("{PropertyName} length at max 150");

            
            //RuleFor(p => p.ShippingAddress)
            //    .NotNull().WithMessage("{PropertyName} is Required");

            RuleFor(p => p.OrderItems)
                .NotEmpty().WithMessage("{PropertyName} is Required");
        }
    }
}
