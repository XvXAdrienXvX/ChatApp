using AuthGateway.Domain;

namespace AuthGateway.Services
{
    public interface IUserService
    {
        Task<Users> CreateAsync(Users user);

        Task<Users?> GetAsync(int id);

        Task<Users> UpdateAsync(Users user);

        Task<bool> DeleteAsync(int id);
    }
}
