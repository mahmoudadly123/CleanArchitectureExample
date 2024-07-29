using MediatR;

namespace CleanArchitecture.Domain.Abstract
{
    /// <summary>
    /// Any thing not have Id
    /// </summary>
    public abstract class ValueObject:IEquatable<ValueObject>
    {

        #region Fields

        private readonly List<INotification> _notifications = new();

        #endregion


        #region Properties

        public abstract IEnumerable<object> GetAtomicValues();

        public IReadOnlyCollection<INotification> Notifications => _notifications;

        #endregion


        #region Equality

        public bool Equals(ValueObject? other)=> other is not null && ValuesAreEqual(other);

        public override bool Equals(object? obj)
        {
            if (ReferenceEquals(obj, null)) return false;

            if (obj.GetType() != GetType()) return false;

            if (ValuesAreEqual((ValueObject)obj)==false) return false;

            return ReferenceEquals(this, obj);
        }

        public override int GetHashCode()=>GetAtomicValues().Aggregate(default(int), HashCode.Combine);

        public static bool operator ==(ValueObject obj1, ValueObject obj2) => obj1.Equals(obj2);
        public static bool operator !=(ValueObject obj1, ValueObject obj2)=> !(obj1 == obj2);

        #endregion

        #region Notifications

        public void RaiseNotification(INotification notification)
        {
            _notifications.Add(notification);
        }

        public void ClearNotifications() => _notifications.Clear();

       
        #endregion

        #region Helper

        private bool ValuesAreEqual(ValueObject other)=> GetAtomicValues().SequenceEqual(other.GetAtomicValues());
        

        #endregion

    }
}
