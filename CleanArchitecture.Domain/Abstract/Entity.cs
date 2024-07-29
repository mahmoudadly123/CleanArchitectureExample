using MediatR;

namespace CleanArchitecture.Domain.Abstract;

/// <summary>
/// Any thing has Id
/// </summary>
/// <typeparam name="TId"></typeparam>
public abstract class Entity<TId>
{

    #region Fields

    private readonly List<INotification> _notifications = new();

    #endregion


    #region Properites

    public TId Id { get; private init; }

    public DateTime CreatedDate { get; private set; }
    public int CreatedBy { get; private set; }

    public DateTime UpdatedDate { get; set; }
    public int UpdatedBy { get;  set; }


    public IReadOnlyCollection<INotification> Notifications => _notifications;

    #endregion

    #region Constructors

    protected Entity()
    {
        Id = default(TId)!;
        CreatedDate = DateTime.Now;
        UpdatedDate = DateTime.Now;
    }

    protected Entity(TId id)
    {
        Id = id;
        CreatedDate= DateTime.Now;
        UpdatedDate= DateTime.Now;
    }
    protected Entity(TId id,DateTime createdDate,DateTime updatedDate,int createdBy,int updatedBy)
    {
        Id = id;
        CreatedDate = createdDate;
        UpdatedDate = updatedDate;
        CreatedBy = createdBy;
        UpdatedBy = updatedBy;
    }

    #endregion


    #region Equality

    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(obj, null)) return false;

        if (ReferenceEquals(this, obj)) return true;

        if (obj is not Entity<TId>) return false;

        if (obj.GetType() != GetType()) return false;

        var other = obj as Entity<TId>;

        if (Id == null || other!.Id == null) return false;

        return Id.Equals(other.Id);
    }

    public override int GetHashCode()
    {
        // ReSharper disable once BaseObjectGetHashCodeCallInGetHashCode
        return Id != null ? Id.GetHashCode() : base.GetHashCode();
    }

    public static bool operator ==(Entity<TId>? obj1, Entity<TId>? obj2)
    {
        return obj1?.Equals(obj2) ?? ReferenceEquals(obj2, null);
    }

    public static bool operator !=(Entity<TId>? obj1, Entity<TId>? obj2)
    {
        return !(obj1 == obj2);
    }

    #endregion

    #region Notifications

    /// <summary>
    /// Store Notification inside Notifications Array to be Published later using PublishNotifications Method
    /// </summary>
    /// <param name="notification"></param>
    public void RegisterNotification(INotification notification)
    {
        _notifications.Add(notification);
    }

    /// <summary>
    /// Clear All Notifications inside Notifications Array
    /// </summary>
    public void ClearNotifications() => _notifications.Clear();

    #endregion

}