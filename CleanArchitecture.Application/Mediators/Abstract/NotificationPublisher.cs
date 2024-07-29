using MediatR;

namespace CleanArchitecture.Application.Mediators.Abstract;

public interface INotificationPublisher
{
    /// <summary>
    /// Send All Notifications to its Handlers to be Processed
    /// </summary>
    Task PublishNotificationsAsync(IReadOnlyCollection<INotification> notifications, CancellationToken cancellationToken);

    /// <summary>
    /// Send All Notifications to its Handlers to be Processed
    /// </summary>
    Task PublishNotificationsAsync(List<INotification> notifications, CancellationToken cancellationToken);

    /// <summary>
    /// Send Notification to be Handled by its Notification Handlers to be processed
    /// </summary>
    /// <param name="notification"></param>
    /// <param name="cancellationToken"></param>
    Task PublishNotificationAsync(INotification notification, CancellationToken cancellationToken);
}

public class NotificationPublisher : INotificationPublisher
{
    #region Fields

    private readonly IPublisher _publisher;

    #endregion

    #region Constructors

    public NotificationPublisher(IPublisher publisher)
    {
        _publisher = publisher;
    }

    #endregion

    #region Methods

    public async Task PublishNotificationsAsync(IReadOnlyCollection<INotification> notifications,CancellationToken cancellationToken)
    {
        foreach (var notification in notifications)
        {
            await _publisher.Publish(notification, cancellationToken);
        }
    }

    public async Task PublishNotificationsAsync(List<INotification> notifications, CancellationToken cancellationToken)
    {
        foreach (var notification in notifications)
        {
            await _publisher.Publish(notification, cancellationToken);
        }
    }

    public async Task PublishNotificationAsync(INotification notification, CancellationToken cancellationToken)
    {
        await _publisher.Publish(notification, cancellationToken);
    }

    #endregion
}