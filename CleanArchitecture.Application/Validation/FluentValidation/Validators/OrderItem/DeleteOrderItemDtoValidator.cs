using CleanArchitecture.Application.ObjectMapping.AutoMapper.Dtos.OrderItem;
using CleanArchitecture.Application.Validation.FluentValidation.Abstract;
using FluentValidation;

namespace CleanArchitecture.Application.Validation.FluentValidation.Validators.OrderItem
{
    public class DeleteOrderItemDtoValidator:BaseValidator<DeleteOrderItemDto>
    {
        public DeleteOrderItemDtoValidator()
        {
            RuleFor(p => p.Id)
                .NotNull().WithMessage("{PropertyName} is required")
                .NotEqual(0).WithMessage("{PropertyName} is required");
        }
    }
}
