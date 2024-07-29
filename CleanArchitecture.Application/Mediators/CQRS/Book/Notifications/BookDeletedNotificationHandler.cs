using CleanArchitecture.Domain.Notifications.Book;
using MediatR;

namespace CleanArchitecture.Application.Mediators.CQRS.Book.Notifications;

public class BookDeletedNotificationHandler : INotificationHandler<BookDeletedNotification>
{
    public async Task Handle(BookDeletedNotification notification, CancellationToken cancellationToken)
    {
        //Set Logic For Handle this Notification like Log it or Send Email
    }
}