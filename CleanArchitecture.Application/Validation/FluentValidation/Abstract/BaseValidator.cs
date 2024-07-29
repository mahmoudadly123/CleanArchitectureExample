using CleanArchitecture.Common.Errors.Abstract;
using FluentValidation;
using FluentValidation.Results;

namespace CleanArchitecture.Application.Validation.FluentValidation.Abstract
{
    public abstract class BaseValidator<TValidator> :AbstractValidator<TValidator> where TValidator:class
    {

    }
}
