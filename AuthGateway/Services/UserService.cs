using AuthGateway.Domain;
using AuthGateway.Repositories;

namespace AuthGateway.Services
{
    public class UserService : IUserService
    {
        private readonly IGenericRepository<Users> _userRepository;


        public UserService(IGenericRepository<Users> userRepository)
        {
            _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
        }
        public async Task<Users> CreateAsync(Users user)
        {
            return await _userRepository.AddAsync(user);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _userRepository.DeleteAsync(id);
        }

        public async Task<Users?> GetAsync(int id)
        {
            return await _userRepository.GetByIdAsync(id);
        }

        public async Task<Users> UpdateAsync(Users user)
        {
            return await _userRepository.UpdateAsync(user);
        }
    }
}
