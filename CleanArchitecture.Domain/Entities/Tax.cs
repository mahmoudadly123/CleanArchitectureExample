using CleanArchitecture.Common.Errors.Abstract;
using CleanArchitecture.Common.Errors.Domain;
using CleanArchitecture.Common.Results;
using CleanArchitecture.Domain.Abstract;
using CleanArchitecture.Domain.Notifications.Tax;

namespace CleanArchitecture.Domain.Entities
{
    public class Tax:Entity<int>
    {
        #region Properites

        public string TaxName { get; private set; }
        public decimal TaxValue { get; private set; }
        public decimal TaxPercent { get; private set; }
        public bool IsActive { get; private set; }

        public int OrderItemId { get; private set; }
        public int OrderId { get; private set; }

        #endregion

        #region Constructors

        private Tax(string taxName, decimal taxValue, bool isActive,int orderItemId,int orderId)
        {
            TaxName = taxName;
            TaxValue = taxValue;
            TaxPercent = 0;
            IsActive = isActive;
            
            OrderItemId = orderItemId;
            OrderId = orderId;
        }
        private Tax(string taxName, decimal taxPercent, int orderItemId, int orderId)
        {
            TaxName = taxName;
            TaxValue = 0;
            TaxPercent = taxPercent;
            IsActive = true;

            OrderItemId = orderItemId;
            OrderId = orderId;
        }

        #endregion

        #region Factory Methods

        public static Result<Tax> Create(string taxName, decimal taxValue, bool isActive, int orderItemId, int orderId)
        {
            //Validation
            var errors = new List<Error>();

            if (string.IsNullOrEmpty(taxName))
                errors.Add(TaxErrors.EmptyName);

            if (taxValue < 0)
                errors.Add(TaxErrors.InvalidTaxValue);


            if (errors.Any())
                return Result.Failure<Tax>(errors);


            var newTax = new Tax(taxName, taxValue, isActive, orderItemId, orderId);

            //Raise Event
            newTax.RegisterNotification(new TaxCreatedNotification(newTax));

            return Result.Success(newTax);
        }
        public static Result<Tax> Create(string taxName, decimal taxPercent, int orderItemId, int orderId)
        {
            //Validation
            var errors = new List<Error>();

            if (string.IsNullOrEmpty(taxName))
                errors.Add(TaxErrors.EmptyName);

            if (taxPercent < 0)
                errors.Add(TaxErrors.InvalidTaxPercent);

            if (errors.Any())
                return Result.Failure<Tax>(errors);


            var newTax = new Tax(taxName, taxPercent, orderItemId, orderId);

            //Raise Event
            newTax.RegisterNotification(new TaxCreatedNotification(newTax));

            return Result.Success(newTax);
        }

        #endregion

        #region Methods

        public Result UpdateTax(string taxName, decimal taxValue, decimal taxPercent, bool isActive,int updatedBy)
        {
            //Validation

            var errors = new List<Error>();

            if (string.IsNullOrEmpty(taxName))
                errors.Add(TaxErrors.EmptyName);

            if (taxValue < 0)
                errors.Add(TaxErrors.InvalidTaxValue);

            if (taxPercent < 0)
                errors.Add(TaxErrors.InvalidTaxPercent);

            if (errors.Any())
                return Result.Failure(errors);


            var originalTax = this;

            TaxName = taxName;
            TaxPercent = taxPercent;
            TaxValue= taxValue;
            IsActive = isActive;

            UpdatedDate=DateTime.Now;
            UpdatedBy = updatedBy;

            var updatedTax = this;

            //Raise Event
            RegisterNotification(new TaxUpdatedNotification(originalTax, updatedTax));

            return Result.Success();
        }

        public Result ChangeTaxName(string taxName)
        {
            //Validation
            if(string.IsNullOrEmpty(taxName)) 
                return Result.Failure(TaxErrors.EmptyName);

            TaxName = taxName;

            return Result.Success();
        }

        public Result SetTaxValue(decimal taxValue)
        {
            //Validation
            if (taxValue<0)
                return Result.Failure(TaxErrors.InvalidTaxValue);

            TaxValue = taxValue;

            return Result.Success();
        }

        public Result SetTaxPercent(decimal taxPercent)
        {
            //Validation
            if (taxPercent < 0)
                return Result.Failure(TaxErrors.InvalidTaxPercent);

            TaxPercent = taxPercent;

            return Result.Success();
        }

        public void SetTaxActive()
        {
            IsActive = true;
        }

        public void SetTaxDisActive()
        {
            IsActive = false;
        }

        #endregion

    }
}
