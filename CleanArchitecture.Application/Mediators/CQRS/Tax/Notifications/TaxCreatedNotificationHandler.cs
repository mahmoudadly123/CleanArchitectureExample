using CleanArchitecture.Domain.Notifications.OrderItem;
using MediatR;

namespace CleanArchitecture.Application.Mediators.CQRS.Tax.Notifications;

public class TaxCreatedNotificationHandler : INotificationHandler<OrderItemCreatedNotification>
{
    public async Task Handle(OrderItemCreatedNotification notification, CancellationToken cancellationToken)
    {
        //Set Logic For Handle this Notification like Log it or Send Email
        await Task.CompletedTask;
    }
}