using AuthGateway.Domain;
using AuthGateway.Services;
using MediatR;

namespace AuthGateway.Contracts.Commands
{
    public record CreateUserCommand : IRequest<string>
    {
        public string Username { get; init; }
        public string Email { get; init; }
        public string Password { get; set; }
    }

    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, string>
    {
        private readonly IUserService _userService;
        private readonly IAuthService _authService;

        public CreateUserCommandHandler(IUserService userService, IAuthService authService)
        {
            _userService = userService ?? throw new ArgumentNullException(nameof(userService));
            _authService = authService ?? throw new ArgumentNullException(nameof(authService));
        }

        public async Task<string> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            string passwordHash = BCrypt.Net.BCrypt.HashPassword(request.Password);
            var entity = new Users
            (
                request.Username,
                request.Email,
                passwordHash,
                "",
                DateTime.UtcNow
            );

            var user = await _userService.CreateAsync(entity);

            if (user is null)
            {
                throw new ArgumentNullException(nameof(user));
            }

            string token = await _authService.GetToken(user);

            return token;
        }
    }
}
