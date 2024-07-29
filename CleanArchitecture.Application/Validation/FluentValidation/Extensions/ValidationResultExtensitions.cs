using CleanArchitecture.Common.Errors.Abstract;
using FluentValidation.Results;

namespace CleanArchitecture.Application.Validation.FluentValidation.Extensions;

public static class ValidationResultExtensions
{
    /// <summary>
    /// Convert List of ValidationFailure To List of Errors
    /// </summary>
    /// <param name="validationResult"></param>
    /// <returns></returns>
    public static List<Error> ToErrors(this ValidationResult validationResult)
    {
        if (validationResult.IsValid)
            return new List<Error>();

        return validationResult.Errors.Select(e=>new Error(e.ErrorCode,e.ErrorMessage)).ToList();

    }
}