using MediatR;

namespace CleanArchitecture.Domain.Notifications.OrderItem;

public class OrderItemUpdatedNotification : INotification
{

    #region Properties

    public Entities.OrderItem OriginalItem { get; private set; }
    public Entities.OrderItem UpdatedItem { get; private set; }
    public DateTime UpdatedDate { get; private set; }

    #endregion



    #region Constructors

    public OrderItemUpdatedNotification(Entities.OrderItem originalItem, Entities.OrderItem updatedItem)
    {
        OriginalItem = originalItem;
        UpdatedItem = updatedItem;
        UpdatedDate = DateTime.Now;
    }

    #endregion

}