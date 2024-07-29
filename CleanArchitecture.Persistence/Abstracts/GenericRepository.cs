using System.Linq.Expressions;
using CleanArchitecture.Application.Interfaces.Persistence.Abstract;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Persistence.Abstracts
{
    public abstract class GenericRepository<TContext,TEntity, TKey> :IGenericRepository<TEntity, TKey> where TContext : DbContext where TEntity : class
    {
        protected readonly TContext DbContext;

        protected GenericRepository(TContext dbContext)
        {
            DbContext= dbContext;
        }

        #region Select Single

        public async Task<TEntity?> GetAsync(TKey id, bool readOnly = false)
        {
            return await DbContext.Set<TEntity>().FindAsync(id);
        }

        public async Task<TEntity?> GetAsync(Expression<Func<TEntity, bool>> predicate, bool readOnly = false)
        {
            return await DbContext.Set<TEntity>().FirstOrDefaultAsync(predicate);
        }

        
        public async Task<bool> ExistAsync(TKey id)
        {
            var entity = await GetAsync(id);
            return entity != null;
        }
        public async Task<bool> ExistAsync(Expression<Func<TEntity, bool>> predicate)
        {
            var entity = await GetAsync(predicate);
            return entity != null;
        }

        #endregion

        #region Select Multi

        public async Task<IEnumerable<TEntity>> GetAllAsync(bool readOnly = false)
        {
            return readOnly ? await DbContext.Set<TEntity>().AsNoTracking().ToListAsync() : await DbContext.Set<TEntity>().ToListAsync();
         
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> predicate,bool readOnly = false)
        {
            return readOnly ? await DbContext.Set<TEntity>().AsNoTracking().Where(predicate).ToListAsync() : await DbContext.Set<TEntity>().Where(predicate).ToListAsync();
        }


        #endregion

        #region Insert

        public async Task<TEntity> AddAsync(TEntity entity, bool saveChanges = false)
        {
            await DbContext.Set<TEntity>().AddAsync(entity);
         
            if(saveChanges)
                await DbContext.SaveChangesAsync();
            
            return entity;
        }

        #endregion

        #region Update

        public async Task UpdateAsync(TEntity entity, bool saveChanges = false)
        {
            DbContext.Set<TEntity>().Update(entity);

            if (saveChanges)
                await DbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(TKey id,TEntity entity, bool saveChanges = false)
        {
            var original = await GetAsync(id);

            DbContext.Entry(original!).CurrentValues.SetValues(entity);

            if (saveChanges)
                await DbContext.SaveChangesAsync();
        }
        #endregion

        #region Delete

        public async Task DeleteAsync(TKey id, bool saveChanges = false)
        {
            var entity = await GetAsync(id,true);

            DbContext.Set<TEntity>().Remove(entity!);

            if (saveChanges)
                await DbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(TEntity entity, bool saveChanges = false)
        {
            DbContext.Set<TEntity>().Remove(entity);

            if (saveChanges)
                await DbContext.SaveChangesAsync();
        }

        public async Task DeleteAllAsync(bool saveChanges = false)
        {
            var entities = await GetAllAsync(true);
            DbContext.Set<TEntity>().RemoveRange(entities);

            if (saveChanges)
                await DbContext.SaveChangesAsync();
        }

        public async Task DeleteAllAsync(Expression<Func<TEntity, bool>> predicate, bool saveChanges = false)
        {
            var entities = await GetAllAsync(predicate,true);
            DbContext.Set<TEntity>().RemoveRange(entities);

            if (saveChanges)
                await DbContext.SaveChangesAsync();
        }

        #endregion

        #region Save Changes

        public async Task SaveChangesAsync()
        {
            await DbContext.SaveChangesAsync();
        }

        #endregion
    }
}
