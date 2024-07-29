using MediatR;

namespace CleanArchitecture.Domain.Notifications.OrderItem;

public class OrderItemCreatedNotification : INotification
{

    #region Properties

    public Entities.OrderItem CreatedItem { get; private set; }
    public DateTime CreatedDate { get; private set; }

    #endregion



    #region Constructors

    public OrderItemCreatedNotification(Entities.OrderItem createdItem)
    {
        CreatedItem = createdItem;

        CreatedDate = DateTime.Now;
    }

    #endregion

}