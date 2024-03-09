using ChatApp.Application.Common.Interfaces;
using ChatApp.Domain.Entities;
using MediatR;

namespace ChatApp.Application.User.Command.LoginUser
{
    public record LoginUserCommand : IRequest<string>
    {
        public int UserId { get; init; }
        public string Username { get; init; }
        public string Email { get; init; }
        public string Password { get; set; }
    }

    public class LoginUserCommandHandler : IRequestHandler<LoginUserCommand, string>
    {
        private readonly IChatDatabaseContext _context;
        private readonly ITokenService _tokenService;

        public LoginUserCommandHandler(IChatDatabaseContext context, ITokenService tokenService)
        {
            _context = context;
            _tokenService = tokenService;
        }

        public async Task<string> Handle(LoginUserCommand request, CancellationToken cancellationToken)
        {
            string token = "";

            var existingUser = _context.Users.FirstOrDefault(x => x.Username == request.Username);
            if (existingUser != null)
            {
                bool isVerified = BCrypt.Net.BCrypt.Verify(request.Password, existingUser.Password);
                if (isVerified)
                {
                    string passwordHash = BCrypt.Net.BCrypt.HashPassword(request.Password);
                    var entity = new Users
                    {
                        Id = existingUser.Id,
                        Username = existingUser.Username,
                        Email = existingUser.Email,
                        Password = passwordHash
                    };

                    token = await _tokenService.GetToken(entity);
                }

            }

            return token;
        }
    }
}
