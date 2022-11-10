using BCrypt.Net;
using ChatApp.Application.Common.Interfaces;
using ChatApp.Domain.Entities;
using ChatApp.Domain.Events;
using MediatR;

namespace ChatApp.Application.User.Command.CreateUser
{
    public record CreateUserCommand : IRequest<string>
    {
        public int UserId { get; init; }
        public string Username { get; init; }
        public string Email { get; init; }
        public string Password { get; set; }
    }

    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, string>
    {
        private readonly IChatDatabaseContext _context;
        private readonly ITokenService _tokenService;

        public CreateUserCommandHandler(IChatDatabaseContext context, ITokenService tokenService)
        {
            _context = context;
            _tokenService = tokenService;
        }

        public async Task<string> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            string passwordHash = BCrypt.Net.BCrypt.HashPassword(request.Password);
            var entity = new Users
            {
                Id = request.UserId,
                Username = request.Username,
                Email = request.Email,
                Password = passwordHash
            };

            entity.AddDomainEvent(new UserCreatedEvent(entity));

            _context.Users.Add(entity);

            await _context.SaveChangesAsync(cancellationToken);
            string token = await _tokenService.GetToken(entity);

            return token;
        }
    }
}
