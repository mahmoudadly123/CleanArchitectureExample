using CleanArchitecture.Common.Errors.Abstract;

namespace CleanArchitecture.Common.Errors.Domain;

public static class ProductErrors
{
    public static readonly Error EmptyName = new Error($"Product.{nameof(EmptyName)}", $"Cant Use Empty Name For Product");
    public static readonly Error EmptyCategory = new Error($"Product.{nameof(EmptyCategory)}", "Cant Use Empty Category For Product");
    public static readonly Error InvalidUnitPrice = new Error($"Product.{nameof(InvalidUnitPrice)}", "Cant Use Invalid Unit Price Category For Product");
}