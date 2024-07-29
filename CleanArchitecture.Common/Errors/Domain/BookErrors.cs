using CleanArchitecture.Common.Errors.Abstract;

namespace CleanArchitecture.Common.Errors.Domain;

public static class BookErrors
{
    public static readonly Error NotFound = new Error("Book.NotFound", "Book Id Not Found");
    public static readonly Error EmptyTitle = new Error("Book.EmptyTitle", "Cant Use Empty Title For Book");
    public static readonly Error EmptyDescription = new Error("Book.EmptyDescription", "Cant Use Empty Description For Book");
    public static readonly Error EmptyCategory = new Error("Book.EmptyDescription", "Cant Use Empty Category For Book");
}