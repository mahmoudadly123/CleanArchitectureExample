using MediatR;

namespace CleanArchitecture.Domain.Notifications.OrderItem;

public class OrderItemDeletedNotification : INotification
{

    #region Properties

    public Entities.OrderItem DeletedItem { get; private set; }
    public DateTime DeletedDate { get; private set; }

    #endregion



    #region Constructors

    public OrderItemDeletedNotification(Entities.OrderItem deletedItem)
    {
        DeletedItem = deletedItem;

        DeletedDate = DateTime.Now;
    }

    #endregion

}