using CleanArchitecture.Application.ObjectMapping.AutoMapper.Dtos.Order;
using CleanArchitecture.Application.Validation.FluentValidation.Abstract;
using FluentValidation;

namespace CleanArchitecture.Application.Validation.FluentValidation.Validators.Order
{
    public class DeleteOrderDtoValidator:BaseValidator<DeleteOrderDto>
    {
        public DeleteOrderDtoValidator()
        {
            RuleFor(p => p.Id)
                .NotNull().WithMessage("{PropertyName} is required")
                .NotEqual(0).WithMessage("{PropertyName} is required");
        }
    }
}
