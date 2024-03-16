using AuthGateway.Domain;

namespace AuthGateway.Services
{
    public interface IAuthService
    {
        Task<string> GetToken(Users user);
    }
}
