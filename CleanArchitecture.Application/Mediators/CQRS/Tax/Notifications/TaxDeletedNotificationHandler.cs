using CleanArchitecture.Domain.Notifications.OrderItem;
using MediatR;

namespace CleanArchitecture.Application.Mediators.CQRS.Tax.Notifications;

public class TaxDeletedNotificationHandler : INotificationHandler<OrderItemDeletedNotification>
{
    public async Task Handle(OrderItemDeletedNotification notification, CancellationToken cancellationToken)
    {
        //Set Logic For Handle this Notification like Log it or Send Email
        await Task.CompletedTask;
    }
}