using CleanArchitecture.Common.Errors.Abstract;

namespace CleanArchitecture.Common.Errors.Domain;

public static class UnitErrors
{
    public static readonly Error EmptyName = new Error("Unit.EmptyName", "Cant Use Empty Name with Unit");
}