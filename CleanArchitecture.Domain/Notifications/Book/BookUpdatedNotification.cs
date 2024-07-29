using MediatR;

namespace CleanArchitecture.Domain.Notifications.Book;

public class BookUpdatedNotification : INotification
{

    #region Properties

    public Entities.Book OriginalBook { get; private set; }
    public Entities.Book UpdatedBook { get; private set; }
    public DateTime UpdatedDate { get; private set; }

    #endregion



    #region Constructors

    public BookUpdatedNotification(Entities.Book originalBook,Entities.Book updatedBook)
    {
        OriginalBook = originalBook;
        UpdatedBook=updatedBook;
        UpdatedDate = DateTime.Now;
    }

    #endregion

}