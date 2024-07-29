using CleanArchitecture.Common.Errors.Abstract;

namespace CleanArchitecture.Common.Errors.Domain;

public static class OrderErrors
{
    public static readonly Error NotFoundOrder = new Error("Order.NotFoundOrder", "Order Id Not Found");

    public static readonly Error EmptyDescription = new Error($"Order.{nameof(EmptyDescription)}", "Cant Add Order with Empty Description");

    public static readonly Error EmptyItems = new Error("Order.EmptyItems", "Cant Add Order with Empty Items");
}