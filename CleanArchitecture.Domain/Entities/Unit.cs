using CleanArchitecture.Common.Errors.Domain;
using CleanArchitecture.Common.Results;
using CleanArchitecture.Domain.Abstract;

namespace CleanArchitecture.Domain.Entities;

public class Unit: Entity<int>
{

    #region Properties

    public string Name { get; private set; }

    #endregion

    #region Constructors

    public Unit()
    {
        Name = string.Empty;
    }
    public Unit(string name)
    {
        Name = name;
    }

    #endregion


    #region Methods


    public Result ChangeName(string name)
    {
        //Validation
        if (string.IsNullOrEmpty(name))
        {
            return Result.Failure(UnitErrors.EmptyName);
        }

        Name = name;

        return Result.Success();
    }

    #endregion


}