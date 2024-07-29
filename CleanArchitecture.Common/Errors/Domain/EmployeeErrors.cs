using CleanArchitecture.Common.Errors.Abstract;

namespace CleanArchitecture.Common.Errors.Domain;

public static class EmployeeErrors
{
    public static readonly Error EmptyName = new Error("Employee.EmptyName", "Cant Use Empty Name For Employee");
    public static readonly Error EmptyJob = new Error("Employee.EmptyJob", "Cant Use Empty Job For Employee");
    public static readonly Error InvalidSalary = new Error("Employee.InvalidSalary", "Cant Use Zero or Negative Salary Value For Employee");
}