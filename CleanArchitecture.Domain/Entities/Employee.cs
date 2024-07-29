using CleanArchitecture.Common.Errors.Domain;
using CleanArchitecture.Common.Results;
using CleanArchitecture.Domain.Abstract;
using CleanArchitecture.Domain.Enums;

namespace CleanArchitecture.Domain.Entities
{
    public class Employee : Entity<int>
    {
        #region Properites

        public string Name { get; private set; }
        public string Job { get; private set; }
        public decimal Salary { get; private set; }
        public bool IsActive { get; private set; }
        public EmployeeType Type { get; private set; }


        #endregion


        #region Constructors

        public Employee()
        {
            Name = string.Empty;
            Job = string.Empty;
            Salary = default;
            IsActive = true;
            Type = EmployeeType.Regular;
        }
        public Employee(string name, string job, EmployeeType type, decimal salary)
        {
            Name = name;
            Job = job;
            Salary = salary;
            Type = type;
            IsActive = true;
        }
        public Employee(string name, string job, EmployeeType type, decimal salary, bool isActive)
        {
            Name = name;
            Job = job;
            Salary = salary;
            Type = type;
            IsActive = isActive;
        }

        #endregion


        #region Methods

        public Result ChangeName(string name)
        {
            //Validation
            if (string.IsNullOrEmpty(name))
            {
                return Result.Failure(EmployeeErrors.EmptyName);
            }

            Name = name;

            return Result.Success();
        }

        public Result ChangeJob(string job)
        {
            //Validation
            if (string.IsNullOrEmpty(job))
            {
                return Result.Failure(EmployeeErrors.EmptyJob);
            }

            Job = job;

            return Result.Success();
        }

        public Result ChangeSalary(decimal salary)
        {
            //Validation
            if (salary <= 0)
            {
                return Result.Failure(EmployeeErrors.InvalidSalary);
            }

            Salary = salary;

            return Result.Success();
        }

        public void ChangeType(EmployeeType type)
        {
            Type = type;
        }

        public void EnableEmployee()
        {
            IsActive = true;
        }

        public void DisableEmployee()
        {
            IsActive = false;
        }

        #endregion
    }
}
