using CleanArchitecture.Domain.Notifications.Order;
using MediatR;

namespace CleanArchitecture.Application.Mediators.CQRS.Order.Notifications;

public class DescriptionChangedForOrderNotificationHandler : INotificationHandler<DescriptionChangedForOrderNotification>
{
    public async Task Handle(DescriptionChangedForOrderNotification notification, CancellationToken cancellationToken)
    {
        //Set Logic For Handle this Notification like Log it or Send Email
        await Task.CompletedTask;
    }
}