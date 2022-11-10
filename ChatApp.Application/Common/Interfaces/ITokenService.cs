using ChatApp.Domain.Entities;

namespace ChatApp.Application.Common.Interfaces
{
    public interface ITokenService
    {
        Task<string> GetToken(Users user);
    }
}
