using CleanArchitecture.Common.Errors.Abstract;

namespace CleanArchitecture.Common.Errors.Domain;

public static class OrderItemErrors
{
    public static readonly Error NotFoundItemId = new Error($"OrderItem.{nameof(NotFoundItemId)}", $"Order Item Id Not Found inside Order Items List");

    public static readonly Error EmptyDescription = new Error($"OrderItem.{nameof(EmptyDescription)}", $"Cant Use Empty Description");
    public static readonly Error InvalidUnitPrice = new Error($"OrderItem.{nameof(InvalidUnitPrice)}", "Cant Use Invalid Unit Price");
    public static readonly Error InvalidQuantity = new Error($"OrderItem.{nameof(InvalidQuantity)}", "Cant Use Invalid Quantity");
    public static readonly Error InvalidAdditionsValue = new Error($"OrderItem.{nameof(InvalidAdditionsValue)}", "Cant Use Invalid Additions Value");
    public static readonly Error InvalidAdditionsPercent = new Error($"OrderItem.{nameof(InvalidAdditionsPercent)}", "Cant Use Invalid Additions Percent");
    public static readonly Error InvalidDiscountValue = new Error($"OrderItem.{nameof(InvalidDiscountValue)}", "Cant Use Invalid Discount Value");
    public static readonly Error InvalidDiscountPercent = new Error($"OrderItem.{nameof(InvalidDiscountPercent)}", "Cant Use Invalid Discount Percent");

    public static readonly Error EmptyTaxes = new Error($"OrderItem.{nameof(EmptyTaxes)}", "Cant Add Empty Taxes inside Order Item");
    

    public static readonly Error ZeroQuantity = new Error($"OrderItem.{nameof(ZeroQuantity)}", "Cant Add Item with Zero Quantity");
    public static readonly Error ZeroUnitPrice = new Error($"OrderItem.{nameof(ZeroUnitPrice)}", "Cant Add Item with Zero Unit Price");
}