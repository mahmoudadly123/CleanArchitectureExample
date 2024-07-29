using MediatR;

namespace CleanArchitecture.Domain.Notifications.Book;

public class BookDeletedNotification : INotification
{

    #region Properties

    public Entities.Book DeletedBook { get; private set; }
    public DateTime DeletedDate { get; private set; }

    #endregion



    #region Constructors

    public BookDeletedNotification(Entities.Book deletedBook)
    {
        DeletedBook = deletedBook;

        DeletedDate = DateTime.Now;
    }

    #endregion

}