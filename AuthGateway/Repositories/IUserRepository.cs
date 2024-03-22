using AuthGateway.Domain;
using System.Linq.Expressions;

namespace AuthGateway.Repositories
{
    public interface IUserRepository
    {
        Task<Users> CreateUserWithRole(Users entity);
        Task<bool> DeleteAsync(object id);
        Task<IEnumerable<Users>> FindAllByConditionAsync(Expression<Func<Users, bool>> predicate);
        IQueryable<Users> FindByConditionAsync(Expression<Func<Users, bool>> predicate);
        Task<IEnumerable<Users>> GetAllAsync();
        Task<Users> GetByIdAsync(object id);
        Task<Users> UpdateAsync(Users entity);
    }
}