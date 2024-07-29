using CleanArchitecture.Common.Errors.Abstract;

namespace CleanArchitecture.Common.Errors.Database;

public static class ConnectionsErrors
{
    public static readonly Error ConnectionDown = new Error("ConnectionsErrors.ConnectionDown", "Cant connect to database, connection is down");
}