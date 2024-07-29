using CleanArchitecture.Domain.Notifications.OrderItem;
using MediatR;

namespace CleanArchitecture.Application.Mediators.CQRS.OrderItem.Notifications;

public class OrderItemCreatedNotificationHandler : INotificationHandler<OrderItemCreatedNotification>
{
    public async Task Handle(OrderItemCreatedNotification notification, CancellationToken cancellationToken)
    {
        //Set Logic For Handle this Notification like Log it or Send Email
        await Task.CompletedTask;
    }
}