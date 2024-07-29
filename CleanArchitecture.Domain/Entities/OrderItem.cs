using CleanArchitecture.Common.Errors.Abstract;
using CleanArchitecture.Common.Errors.Domain;
using CleanArchitecture.Common.Results;
using CleanArchitecture.Domain.Abstract;
using CleanArchitecture.Domain.Notifications.OrderItem;
using CleanArchitecture.Domain.Notifications.Tax;

namespace CleanArchitecture.Domain.Entities;

public class OrderItem:Entity<int>
{
    #region Fields

    private readonly List<Tax> _itemTaxes;

    #endregion

    #region Properites

    public string Description { get; private set; }

    public decimal UnitPrice { get; private set; }

    public decimal Quantity { get; private set; }

    public decimal AdditionsValue { get; private set; }
    public decimal AdditionsPercent { get; private set; }

    public decimal TaxesValue { get; private set; }
    public decimal TaxesPercent { get; private set; }
   

    public decimal DiscountValue { get; private set; }
    public decimal DiscountPercent { get; private set; }


    /// <summary>
    /// الاجمالي قبل الخصم والاضافة والضرائب
    /// </summary>
    public decimal SubTotal => UnitPrice * Quantity;

    /// <summary>
    /// الاجمالي بعد الخصم والاضافة والضرائب
    /// </summary>
    public decimal Total => SubTotal + (AdditionsValue + (AdditionsPercent * SubTotal / 100)) + (TaxesValue + (TaxesPercent * SubTotal / 100)) - (DiscountValue - (DiscountPercent * SubTotal / 100));

    /// <summary>
    /// الضرائب المطبقة علي الصنف
    /// </summary>
    public IReadOnlyCollection<Tax> ItemTaxes => _itemTaxes;


    public int OrderId { get; private set; }

    #endregion

    #region Constructors

    private OrderItem(string description, decimal unitPrice, decimal quantity,int orderId)
    {
        Description = description;
        UnitPrice = unitPrice;
        Quantity = quantity;
        OrderId=orderId;

        _itemTaxes = new List<Tax>();
    }
    private OrderItem(string description, decimal unitPrice, decimal quantity,List<Tax>taxes, int orderId)
    {
        Description = description;
        UnitPrice = unitPrice;
        Quantity = quantity;
        OrderId = orderId;
        _itemTaxes = taxes;

        CalcTaxesValue();
        CalcTaxesPercent();
    }
    private OrderItem(string description, decimal unitPrice, decimal quantity, decimal additionsValue, decimal discountValue, int orderId)
    {
        Description = description;
        UnitPrice = unitPrice;
        Quantity = quantity;
        AdditionsValue = additionsValue;
        DiscountValue = discountValue;
        OrderId = orderId;

        _itemTaxes = new List<Tax>();
        
    }
    private OrderItem(string description, decimal unitPrice, decimal quantity, decimal additionsValue, decimal discountValue,List<Tax> taxes, int orderId)
    {
        Description = description;
        UnitPrice = unitPrice;
        Quantity = quantity;
        AdditionsValue = additionsValue;
        DiscountValue = discountValue;
        OrderId = orderId;
        _itemTaxes = taxes;

        CalcTaxesValue();
        CalcTaxesPercent();
    }

    #endregion

    #region Factory Methods

    public static Result<OrderItem> Create(string description, decimal unitPrice, decimal quantity, int orderId)
    {
        //Validation
        var errors = new List<Error>();

        if (string.IsNullOrEmpty(description))
            errors.Add(OrderItemErrors.EmptyDescription);

        if (unitPrice < 0)
            errors.Add(OrderItemErrors.InvalidUnitPrice);

        if (quantity <= 0)
            errors.Add(OrderItemErrors.InvalidQuantity);

        if (errors.Any())
            return Result.Failure<OrderItem>(errors);


        var newItem = new OrderItem( description,  unitPrice,  quantity,  orderId);

        //Raise Event For Create Order Item
        newItem.RegisterNotification(new OrderItemCreatedNotification(newItem));

        return Result.Success(newItem);
    }
    public static Result<OrderItem> Create(string description, decimal unitPrice, decimal quantity, List<Tax> taxes, int orderId)
    {
        //Validation
        var errors = new List<Error>();

        if (string.IsNullOrEmpty(description))
            errors.Add(OrderItemErrors.EmptyDescription);

        if (unitPrice < 0)
            errors.Add(OrderItemErrors.InvalidUnitPrice);

        if (quantity <= 0)
            errors.Add(OrderItemErrors.InvalidQuantity);

        if (!taxes.Any())
            errors.Add(OrderItemErrors.EmptyTaxes);

        if (errors.Any())
            return Result.Failure<OrderItem>(errors);

        var newItem = new OrderItem(description, unitPrice, quantity, taxes, orderId);

        //Raise Event For Create Order Item
        newItem.RegisterNotification(new OrderItemCreatedNotification(newItem));

        return Result.Success(newItem);
    }
    public static Result<OrderItem> Create(string description, decimal unitPrice, decimal quantity, decimal additionsValue, decimal discountValue, int orderId)
    {
        //Validation

        var errors = new List<Error>();

        if (string.IsNullOrEmpty(description))
            errors.Add(OrderItemErrors.EmptyDescription);

        if (unitPrice < 0)
            errors.Add(OrderItemErrors.InvalidUnitPrice);

        if (quantity <= 0)
            errors.Add(OrderItemErrors.InvalidQuantity);

        if (additionsValue < 0)
            errors.Add(OrderItemErrors.InvalidAdditionsValue);

        if (discountValue < 0)
            errors.Add(OrderItemErrors.InvalidDiscountValue);

        if (errors.Any())
            return Result.Failure<OrderItem>(errors);

        var newItem = new OrderItem(description, unitPrice, quantity, additionsValue, discountValue, orderId);

        //Raise Event For Create Order Item
        newItem.RegisterNotification(new OrderItemCreatedNotification(newItem));

        return Result.Success(newItem);
    }
    public static Result<OrderItem> Create(string description, decimal unitPrice, decimal quantity, decimal additionsValue, decimal discountValue, List<Tax> taxes, int orderId)
    {
        //Validation

        var errors = new List<Error>();

        if (string.IsNullOrEmpty(description))
            errors.Add(OrderItemErrors.EmptyDescription);

        if (unitPrice < 0)
            errors.Add(OrderItemErrors.InvalidUnitPrice);

        if (quantity <= 0)
            errors.Add(OrderItemErrors.InvalidQuantity);

        if (additionsValue < 0)
            errors.Add(OrderItemErrors.InvalidAdditionsValue);

        if (discountValue < 0)
            errors.Add(OrderItemErrors.InvalidDiscountValue);

        if (!taxes.Any())
            errors.Add(OrderItemErrors.EmptyTaxes);

        if (errors.Any())
            return Result.Failure<OrderItem>(errors);

        var newItem = new OrderItem( description,  unitPrice,  quantity,  additionsValue,  discountValue,  taxes,  orderId);

        //Raise Event For Create Order Item
        newItem.RegisterNotification(new OrderItemCreatedNotification(newItem));

        return Result.Success(newItem);
    }

    #endregion

    #region Methods

    #region Order ITem

    public Result UpdateItem(string description, decimal unitPrice, decimal quantity)
    {
        //Validation

        var errors = new List<Error>();

        if (string.IsNullOrEmpty(description))
            errors.Add(OrderItemErrors.EmptyDescription);

        if (unitPrice < 0)
            errors.Add(OrderItemErrors.InvalidUnitPrice);

        if (quantity <= 0)
            errors.Add(OrderItemErrors.InvalidQuantity);

        if (errors.Any())
            return Result.Failure(errors);

        var originalOrderItem = this;

        Description = description;
        UnitPrice = unitPrice;
        Quantity = quantity;

        var updatedOrderITem = this;

        //Raise Event For Update Order Item
        RegisterNotification(new OrderItemUpdatedNotification(originalOrderItem, updatedOrderITem));

        return Result.Success();
    }

    public Result ChangeDescription(string description)
    {
        //Validation
        if(string.IsNullOrEmpty(description))
            return Result.Failure(OrderItemErrors.EmptyDescription);

        Description = description;

        return Result.Success();
    }

    public Result ChangeUnitPrice(decimal unitPrice)
    {
        //Validation
        if (unitPrice < 0)
            return Result.Failure(OrderItemErrors.InvalidUnitPrice);

        UnitPrice = unitPrice;

        return Result.Success();
    }

    public Result UpdateQuantity(decimal quantity)
    {
        //Validation
        if (quantity <= 0)
            return Result.Failure(OrderItemErrors.InvalidQuantity);

        Quantity = quantity;

        return Result.Success();
    }

    public Result SetAdditionsValue(decimal additionsValue)
    {
        //Validation
        if (additionsValue <= 0)
            return Result.Failure(OrderItemErrors.InvalidAdditionsValue);

        AdditionsValue = additionsValue;

        return Result.Success();
    }

    public Result SetAdditionsPercent(decimal additionsPercent)
    {
        //Validation
        if (additionsPercent <= 0)
            return Result.Failure(OrderItemErrors.InvalidAdditionsPercent);


        AdditionsPercent = additionsPercent;

        return Result.Success();
    }

    public Result SetDiscountPercent(decimal discountPercent)
    {
        //Validation
        if (discountPercent <= 0)
            return Result.Failure(OrderItemErrors.InvalidDiscountPercent);

        DiscountPercent = discountPercent;

        return Result.Success();
    }

    public Result SetDiscountValue(decimal discountValue)
    {
        //Validation
        if (discountValue <= 0)
            return Result.Failure(OrderItemErrors.InvalidDiscountValue);

        DiscountValue = discountValue;

        return Result.Success();
    }

    #endregion

    #region Tax

    public Result AddTaxValue(string taxName, decimal taxValue)
    {
        var newTax = Tax.Create(taxName, taxValue, true, Id, OrderId);

        if (newTax.IsSuccess)
        {
            _itemTaxes.Add(newTax.Value!);

            CalcTaxesValue();
        }

        return Result.Failure(newTax.Errors);
    }

    public Result AddTaxPercent(string taxName, decimal taxPercent)
    {
        var newTax = Tax.Create(taxName, taxPercent,Id, OrderId);

        if (newTax.IsSuccess)
        {
            _itemTaxes.Add(newTax.Value!);

            CalcTaxesPercent();
        }

        return Result.Failure(newTax.Errors);
    }

    public Result UpdateTax(int taxId, string taxName, decimal taxValue, decimal taxPercent,bool isActive,int updatedBy)
    {
        var findTax = _itemTaxes.FirstOrDefault(c => c.Id == taxId);

        if (findTax is null)
            return Result.Failure(TaxErrors.NotFoundId);


        var updateResult = findTax.UpdateTax( taxName,  taxValue,  taxPercent,  isActive,  updatedBy);


        return updateResult.IsSuccess ? Result.Success() : Result.Failure(updateResult.Errors);
    }

    public void RemoveTax(Tax tax)
    {
        //Raise Notification
        RegisterNotification(new TaxDeletedNotification(tax));

        _itemTaxes.Remove(tax);
    }


    public void ActiveTax(string taxName)
    {
        var findTax = _itemTaxes.FirstOrDefault(x => x.TaxName == taxName);

        if (findTax != null)
        {
            findTax.SetTaxActive();
        }
    }

    public void DeActiveTax(string taxName)
    {
        var findTax = _itemTaxes.FirstOrDefault(x => x.TaxName == taxName);

        if (findTax != null)
        {
            findTax.SetTaxDisActive();
        }
    }

    private void CalcTaxesValue()
    {
        TaxesValue = _itemTaxes.Sum(s => s.TaxValue);
    }

    private void CalcTaxesPercent()
    {
        TaxesPercent = _itemTaxes.Sum(s => s.TaxPercent);
    }

    #endregion

    #endregion
}