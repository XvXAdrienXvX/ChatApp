using Microsoft.Data.SqlClient;
using System.Linq.Expressions;

namespace AuthGateway.Repositories
{
    public interface IRepositoryBase<TEntity> where TEntity : class
    {
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<IEnumerable<TEntity>> FindAllByConditionAsync(Expression<Func<TEntity, bool>> predicate);
        IQueryable<TEntity> FindByConditionAsync(Expression<Func<TEntity, bool>> predicate);
        Task<TEntity> GetByIdAsync(object id);
        Task<TEntity> AddAsync(TEntity entity);
        Task<TEntity> UpdateAsync(TEntity entity);
        Task<bool> DeleteAsync(object id);
        
     }

}
