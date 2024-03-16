using System.Linq.Expressions;

namespace AuthGateway.Repositories
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<IEnumerable<TEntity>> FindByConditionAsync(Expression<Func<TEntity, bool>> predicate);
        Task<TEntity> GetByIdAsync(object id);
        Task<TEntity> AddAsync(TEntity entity);
        Task<TEntity> UpdateAsync(TEntity entity);
        Task<bool> DeleteAsync(object id);
    }

}
