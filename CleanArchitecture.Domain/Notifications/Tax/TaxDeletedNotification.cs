using MediatR;

namespace CleanArchitecture.Domain.Notifications.Tax;

public class TaxDeletedNotification : INotification
{

    #region Properties

    public Entities.Tax DeletedTax { get; private set; }
    public DateTime DeletedDate { get; private set; }

    #endregion



    #region Constructors

    public TaxDeletedNotification(Entities.Tax deletedTax)
    {
        DeletedTax = deletedTax;

        DeletedDate = DateTime.Now;
    }

    #endregion

}