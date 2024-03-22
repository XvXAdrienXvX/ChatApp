using AuthGateway.Domain;
using AuthGateway.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Transactions;

namespace AuthGateway.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(
            IUserRepository userRepository
        )
        {
            _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
        }

        public async Task<Users> CreateAsync(Users user)
        {
            try
            {    
                return await  _userRepository.CreateUserWithRole(user);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
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
