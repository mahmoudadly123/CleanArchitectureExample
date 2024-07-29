using CleanArchitecture.Domain.Notifications.OrderItem;
using MediatR;

namespace CleanArchitecture.Application.Mediators.CQRS.OrderItem.Notifications;

public class OrderItemDeletedNotificationHandler : INotificationHandler<OrderItemDeletedNotification>
{
    public async Task Handle(OrderItemDeletedNotification notification, CancellationToken cancellationToken)
    {
        //Set Logic For Handle this Notification like Log it or Send Email
        await Task.CompletedTask;
    }
}