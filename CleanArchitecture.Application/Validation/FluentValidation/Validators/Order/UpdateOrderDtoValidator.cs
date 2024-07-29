using CleanArchitecture.Application.ObjectMapping.AutoMapper.Dtos.Order;
using CleanArchitecture.Application.Validation.FluentValidation.Abstract;
using FluentValidation;

namespace CleanArchitecture.Application.Validation.FluentValidation.Validators.Order
{
    public class UpdateOrderDtoValidator : BaseValidator<UpdateOrderDto>
    {
        public UpdateOrderDtoValidator()
        {
            RuleFor(p => p.ShippingAddress)
                .NotNull().WithMessage("{PropertyName} is Required");

            RuleFor(p => p.OrderItems)
                .NotEmpty().WithMessage("{PropertyName} is Required");

        }
    }
}
