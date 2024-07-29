using CleanArchitecture.Domain.Notifications.Book;
using MediatR;

namespace CleanArchitecture.Application.Mediators.CQRS.Book.Notifications;

public class BookUpdatedNotificationHandler : INotificationHandler<BookUpdatedNotification>
{
    public async Task Handle(BookUpdatedNotification notification, CancellationToken cancellationToken)
    {
        //Set Logic For Handle this Notification like Log it or Send Email
    }
}