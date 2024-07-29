using CleanArchitecture.Application.Interfaces.Persistence.Abstract;
using CleanArchitecture.Persistence.Contexts;

namespace CleanArchitecture.Persistence.Abstracts;


public class UnitOfWork : IUnitOfWork 
{
    #region Properties

    public ApplicationDbContext DbContext { get; private set; }

    #endregion

    #region Properties

    public UnitOfWork(ApplicationDbContext dbContext)
    {
        DbContext = dbContext;
    }

    #endregion

    #region Methods

    public Task SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return DbContext.SaveChangesAsync(cancellationToken);
    }

    #endregion
}

/*
public class UnitOfWork<TDbContext> : IUnitOfWork where TDbContext : DbContext
{
    #region Properties

    public TDbContext DbContext { get; private set; }

    #endregion

    #region Properties

    public UnitOfWork(TDbContext dbContext)
    {
        DbContext = dbContext;
    }

    #endregion

    #region Methods

    public Task SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return DbContext.SaveChangesAsync(cancellationToken);
    }

    #endregion
}
*/