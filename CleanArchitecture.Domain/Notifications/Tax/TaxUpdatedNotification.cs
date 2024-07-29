using MediatR;

namespace CleanArchitecture.Domain.Notifications.Tax;

public class TaxUpdatedNotification : INotification
{

    #region Properties

    public Entities.Tax OriginalTax { get; private set; }
    public Entities.Tax UpdatedTax { get; private set; }
    public DateTime UpdatedDate { get; private set; }

    #endregion



    #region Constructors

    public TaxUpdatedNotification(Entities.Tax originalTax, Entities.Tax updatedTax)
    {
        OriginalTax = originalTax;
        UpdatedTax = updatedTax;
        UpdatedDate = DateTime.Now;
    }

    #endregion

}