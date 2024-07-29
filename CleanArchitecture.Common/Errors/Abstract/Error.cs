namespace CleanArchitecture.Common.Errors.Abstract;

public class Error
{
    #region Properites

    public string Code { get; }
    public string Message { get; }

    #endregion

    #region Statics

    public static readonly Error None = new(string.Empty, string.Empty);
    public static readonly Error Null = new("Error.Null", "The Specified Value Result is Null");

    #endregion

    #region Constructors

    public Error(string message)
    {
        Code = string.Empty;
        Message = message;
    }
    public Error(string code, string message)
    {
        Code = code;
        Message = message;
    }


    #endregion

    #region Operators

    public static implicit operator string(Error error) => error.Code;

    #endregion


    #region Equality

    public static bool operator ==(Error? left, Error? right)
    {
        if (left is null && right is null) return true;

        if (left is null || right is null) return false;

        if (left.Code == right.Code) return true;

        return false;
    }

    public static bool operator !=(Error? left, Error? right)
    {
        return !(left == right);
    }

    protected bool Equals(Error other)
    {
        return Code == other.Code && Message == other.Message;
    }

    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != GetType()) return false;
        return Equals((Error)obj);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Code, Message);
    }

    #endregion

}