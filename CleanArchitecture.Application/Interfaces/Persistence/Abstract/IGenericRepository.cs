using System.Linq.Expressions;

namespace CleanArchitecture.Application.Interfaces.Persistence.Abstract
{
    public interface IGenericRepository<TEntity, TKey> where TEntity : class
    {
        #region Select Single

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="readOnly">true:no tracking for changes just for read , false:enable tracking for changes</param>
        /// <returns></returns>
        Task<TEntity?> GetAsync(TKey id,bool readOnly=false);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="predicate"></param>
        /// <param name="readOnly">true:no tracking for changes just for read , false:enable tracking for changes</param>
        /// <returns></returns>
        Task<TEntity?> GetAsync(Expression<Func<TEntity, bool>> predicate,bool readOnly=false);


        Task<bool> ExistAsync(TKey id);
        Task<bool> ExistAsync(Expression<Func<TEntity, bool>> predicate);

        #endregion

        #region Select Multi

        /// <summary>
        /// 
        /// </summary>
        /// <param name="readOnly">true:no tracking for changes just for read , false:enable tracking for changes</param>
        /// <returns></returns>
        Task<IEnumerable<TEntity>> GetAllAsync(bool readOnly = false);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="predicate"></param>
        /// <param name="readOnly">true:no tracking for changes just for read , false:enable tracking for changes</param>
        /// <returns></returns>
        Task<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> predicate, bool readOnly = false);

        #endregion

        #region Insert

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="saveChanges">true:mean save changes direct to database,false:mean like unit of work and save changes after call function SaveChanges of repository or db Context</param>
        /// <returns></returns>
        Task<TEntity> AddAsync(TEntity entity,bool saveChanges=false);
        #endregion

        #region Update

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="saveChanges">true:mean save changes direct to database,false:mean like unit of work and save changes after call function SaveChanges of repository or db Context</param>
        /// <returns></returns>
        Task UpdateAsync(TEntity entity, bool saveChanges = false);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="entity"></param>
        /// <param name="saveChanges">true:mean save changes direct to database,false:mean like unit of work and save changes after call function SaveChanges of repository or db Context</param>
        /// <returns></returns>
        Task UpdateAsync(TKey id, TEntity entity, bool saveChanges = false);
        #endregion

        #region Delete

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="saveChanges">true:mean save changes direct to database,false:mean like unit of work and save changes after call function SaveChanges of repository or db Context</param>
        /// <returns></returns>
        Task DeleteAsync(TKey id, bool saveChanges = false);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="saveChanges">true:mean save changes direct to database,false:mean like unit of work and save changes after call function SaveChanges of repository or db Context</param>
        /// <returns></returns>
        Task DeleteAsync(TEntity entity, bool saveChanges = false);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="saveChanges">true:mean save changes direct to database,false:mean like unit of work and save changes after call function SaveChanges of repository or db Context</param>
        /// <returns></returns>
        Task DeleteAllAsync(bool saveChanges=false);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="predicate"></param>
        /// <param name="saveChanges">true:mean save changes direct to database,false:mean like unit of work and save changes after call function SaveChanges of repository or db Context</param>
        /// <returns></returns>
        Task DeleteAllAsync(Expression<Func<TEntity, bool>> predicate, bool saveChanges = false);

        #endregion

        #region SaveChanges

        /// <summary>
        /// Save All Changes From Repository DbContext to Database
        /// </summary>
        /// <returns></returns>
        Task SaveChangesAsync();

        #endregion
    }
}
