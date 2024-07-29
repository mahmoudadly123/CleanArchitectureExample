using CleanArchitecture.Common.Errors.Abstract;

namespace CleanArchitecture.Common.Errors.Domain;

public static class TaxErrors
{
    public static readonly Error NotFoundId = new Error("Tax.NotFoundId", "Tax Id Not Exist inside Item Taxes List");
    public static readonly Error EmptyName = new Error("Tax.EmptyName", "Cant Use Empty Name with Tax");
    public static readonly Error InvalidTaxValue = new Error("Tax.InvalidTaxValue", "Cant Use Negative Value with Tax");
    public static readonly Error InvalidTaxPercent = new Error("Tax.InvalidTaxPercent", "Cant Use Negative Percent with Tax");
}