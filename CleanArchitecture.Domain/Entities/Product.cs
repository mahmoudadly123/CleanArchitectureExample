using CleanArchitecture.Common.Errors.Domain;
using CleanArchitecture.Common.Results;
using CleanArchitecture.Domain.Abstract;

namespace CleanArchitecture.Domain.Entities;

public class Product : Entity<int>
{
    #region Properties

    public string Name { get; private set; }
    public string Category { get; private set; }
    public decimal UnitPrice { get; private set; }
    public bool IsActive { get; private set; }
    public Unit Unit { get; private set; }

    #endregion

    #region Constructors

    public Product()
    {
        Name = string.Empty;
        Category = string.Empty;
        UnitPrice = default;
        IsActive = true;
        Unit = new Unit();
    }
    public Product(string name, string category, decimal unitPrice, bool isActive, Unit unit)
    {
        Name = name;
        Category = category;
        UnitPrice = unitPrice;
        IsActive = isActive;
        Unit = unit;
    }

    #endregion

    #region Methods

    public Result ChangeName(string name)
    {
        //Validation
        if(string.IsNullOrEmpty(name))
            return Result.Failure(ProductErrors.EmptyName);

        Name = name;

        return Result.Success();
    }

    public Result ChangeCategory(string category)
    {
        //Validation
        if (string.IsNullOrEmpty(category))
            return Result.Failure(ProductErrors.EmptyCategory);

        Category = category;

        return Result.Success();
    }

    public Result ChangeUnitPrice(decimal price)
    {
        //Validation
        if(price<0)
            return Result.Failure(ProductErrors.InvalidUnitPrice);

        UnitPrice = price;

        return Result.Success();
    }

    public void ChangeUnit(Unit unit)
    {
        Unit = unit;
    }

    public void EnableProduct()
    {
        IsActive = true;
    }

    public void DisableProduct()
    {
        IsActive = false;
    }

    #endregion
}