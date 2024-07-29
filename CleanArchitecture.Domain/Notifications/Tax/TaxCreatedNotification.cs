using MediatR;

namespace CleanArchitecture.Domain.Notifications.Tax;

public class TaxCreatedNotification : INotification
{

    #region Properties

    public Entities.Tax CreatedTax { get; private set; }
    public DateTime CreatedDate { get; private set; }

    #endregion



    #region Constructors

    public TaxCreatedNotification(Entities.Tax createdTax)
    {
        CreatedTax = createdTax;

        CreatedDate = DateTime.Now;
    }

    #endregion

}