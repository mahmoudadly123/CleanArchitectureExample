namespace CleanArchitecture.Application.Interfaces.Persistence.Abstract;

/// <summary>
/// Represent DbContext
/// </summary>
public interface IUnitOfWork
{
    //Save All Changes inside DbContext as Unit of work
    public Task SaveChangesAsync(CancellationToken cancellationToken);
}