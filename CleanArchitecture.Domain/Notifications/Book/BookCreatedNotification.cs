using MediatR;

namespace CleanArchitecture.Domain.Notifications.Book;

public class BookCreatedNotification : INotification
{

    #region Properties

    public Entities.Book CreatedBook { get; private set; }
    public DateTime CreatedDate { get; private set; }

    #endregion



    #region Constructors

    public BookCreatedNotification(Entities.Book createdBook)
    {
        CreatedBook = createdBook;

        CreatedDate = DateTime.Now;
    }

    #endregion

}