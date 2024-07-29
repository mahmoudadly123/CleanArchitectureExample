using CleanArchitecture.Common.Errors.Domain;
using CleanArchitecture.Common.Results;
using CleanArchitecture.Domain.Abstract;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Notifications.Order;
using CleanArchitecture.Domain.Notifications.OrderItem;
using CleanArchitecture.Domain.ValueObjects;

namespace CleanArchitecture.Domain.Aggregates;

public class Order : AggregateRoot<int>
{
    #region Fields

    private readonly List<OrderItem> _orderItems;


    #endregion

    #region Properites

    public string OrderNumber { get; private set; }
    public DateTime OrderDate { get; private set; }
    public string OrderDescription { get; private set; }
    public ShippingAddress ShippingAddress { get; private set; }

    public IReadOnlyCollection<OrderItem> OrderItems => _orderItems;

    #endregion

    #region Constructors

    public Order()
    {
        OrderNumber = string.Empty;
        OrderDate=DateTime.Now;
        OrderDescription = string.Empty;
        ShippingAddress = new ShippingAddress();
        _orderItems = new List<OrderItem>();
    }

    private Order(string orderNumber, DateTime orderDate, string orderDescription)
    {
        OrderNumber = orderNumber;
        OrderDate = orderDate;
        OrderDescription = orderDescription;
        ShippingAddress = new ShippingAddress();
        _orderItems = new List<OrderItem>();
    }

    #endregion

    #region Factory Methods

    public static Order Create(string orderNumber, DateTime orderDate, string orderDescription)
    {
        return new Order(orderNumber, orderDate, orderDescription);
    }

    #endregion

    #region Methods

    #region Order

    public Result ChangeDescription(string description)
    {
        //Validation
        if (string.IsNullOrEmpty(description))
            return Result.Failure(OrderErrors.EmptyDescription);

        //Raise Notification
        RegisterNotification(new DescriptionChangedForOrderNotification(OrderDescription, description, Id));

        OrderDescription = description;

        return Result.Success();
    }

    #endregion

    #region Order Items

    public Result AddItem(string description, decimal unitPrice, decimal quantity)
    {
        var newOrderItem = OrderItem.Create(description, unitPrice, quantity, Id);

        if (newOrderItem.IsFailure)
            return Result.Failure(newOrderItem.Errors);

        _orderItems.Add(newOrderItem.Value!);

        return Result.Success();
        
    }
    public Result AddItem(string description, decimal unitPrice, decimal quantity, List<Tax> taxes)
    {
        var newOrderItem = OrderItem.Create(description, unitPrice, quantity, taxes, Id);

        if (newOrderItem.IsSuccess)
        {
            _orderItems.Add(newOrderItem.Value!);
        }

        return Result.Failure(newOrderItem.Errors);
    }
    public Result AddItem(string description, decimal unitPrice, decimal quantity, decimal additionsValue, decimal discountValue)
    {
        var newOrderItem = OrderItem.Create(description, unitPrice, quantity, additionsValue, discountValue, Id);

        if (newOrderItem.IsSuccess)
        {
            _orderItems.Add(newOrderItem.Value!);
        }

        return Result.Failure(newOrderItem.Errors);
    }
    public Result AddItem(string description, decimal unitPrice, decimal quantity, decimal additionsValue, decimal discountValue, List<Tax> taxes)
    {
        var newOrderItem = OrderItem.Create(description, unitPrice, quantity, additionsValue, discountValue, taxes, Id);

        if (newOrderItem.IsSuccess)
        {
            _orderItems.Add(newOrderItem.Value!);
        }

        return Result.Failure(newOrderItem.Errors);
    }

    public Result UpdateItem(int orderItemId, string description, decimal unitPrice, decimal quantity)
    {
        var findItem = _orderItems.FirstOrDefault(c => c.Id == orderItemId);

        if (findItem is null)
            return Result.Failure(OrderItemErrors.NotFoundItemId);


        var updateResult = findItem.UpdateItem(description, unitPrice, quantity);


        return updateResult.IsSuccess ? Result.Success() : Result.Failure(updateResult.Errors);
    }

    public void RemoveItem(OrderItem removeItem)
    {
        //Raise Notification
        RegisterNotification(new OrderItemDeletedNotification(removeItem));

        _orderItems.Remove(removeItem);

    }

    
    public Result Add_Items_From_List_Of_OrderItems(List<OrderItem> orderItems)
    {
        foreach (var orderItemDto in orderItems)
        {
            //Insert All New Items from items Dto Not Exist inside Current Order Items List

            var itemExistInsideEntity = OrderItems.FirstOrDefault(c => c.Id == orderItemDto.Id);

            if (itemExistInsideEntity == null)
            {
                var createOrderItemResult = AddItem(orderItemDto.Description, orderItemDto.UnitPrice, orderItemDto.Quantity);

                if (createOrderItemResult.IsFailure)
                    return Result.Failure(createOrderItemResult.Errors);
            }

        }

        return Result.Success();
    }

    public Result Update_Items_From_List_Of_OrderItems(List<OrderItem> orderItems)
    {
        foreach (var currentOrderItem in OrderItems)
        {
            //Update All Items inside current Entity from Dto of items list

            var itemExistInsideDto = orderItems.FirstOrDefault(c => c.Id == currentOrderItem.Id);

            if (itemExistInsideDto != null)
            {
                var updateOrderItemResult = UpdateItem(itemExistInsideDto.Id, itemExistInsideDto.Description, itemExistInsideDto.UnitPrice, itemExistInsideDto.Quantity);

                if (updateOrderItemResult.IsFailure)
                    return Result.Failure(updateOrderItemResult.Errors);
            }
        }

        return Result.Success();
    }

    public Result Remove_Items_NotExist_Inside_List_Of_OrderItems(List<OrderItem> orderItems)
    {
        foreach (var currentOrderItem in OrderItems)
        {
            //Delete All Items from current Entity that not exist inside Dto of items list

            var itemExistInsideDto = orderItems.FirstOrDefault(c => c.Id == currentOrderItem.Id);

            if (itemExistInsideDto == null)
                RemoveItem(currentOrderItem);
        }

        return Result.Success();
    }

    #endregion

    #region Shipping Address

    public Result SetShippingAddress(string country, string city, string region, string street, string building, string floor, string apartment)
    {
        var shippingAddressResult = ShippingAddress.Create(country, city, region, street, building, floor, apartment);

        if (shippingAddressResult.IsSuccess)
        {
            ShippingAddress = shippingAddressResult.Value!;

            return Result.Success();
        }

        return Result.Failure(shippingAddressResult.Errors);

    }

    #endregion

    #endregion
}