using CleanArchitecture.Application.Interfaces.Infrastructure;
using CleanArchitecture.Application.Interfaces.Persistence.Repositories;
using CleanArchitecture.Domain.Notifications.Book;
using MediatR;

namespace CleanArchitecture.Application.Mediators.CQRS.Book.Notifications;

public class BookCreatedNotificationHandler : INotificationHandler<BookCreatedNotification>
{
    private readonly IBookRepository _bookRepository;
    private readonly IEmailSenderService _emailSenderService;

    public BookCreatedNotificationHandler(IBookRepository bookRepository,IEmailSenderService emailSenderService)
    {
        _bookRepository = bookRepository;
        _emailSenderService = emailSenderService;
    }

    public async Task Handle(BookCreatedNotification notification, CancellationToken cancellationToken)
    {
        //Set Logic For Handle this Notification like Log it or Send Email
        var createdBookExist = await _bookRepository.GetAsync(notification.CreatedBook.Id, true);

        if (createdBookExist == null)
        {
            return;
        }

        //Send Email Notification
        //await _emailSenderService.SendEmailAsync(new Email
        //{
        //    Subject = "Create New Book",
        //    Body = $"We Created New Book with Title = ({createdBookExist.Title}) , with Id = {createdBookExist.Id}"
        //});
    }
}