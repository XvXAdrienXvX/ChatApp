using AutoMapper;
using ChatApp.Application.Common.Interfaces;
using ChatApp.Application.User.DTO;
using MediatR;

namespace ChatApp.Application.User.Query
{
    public record GetUsersQuery : IRequest<UserListDTO>
    {
    }

    public class GetUsersQueryHandler : IRequestHandler<GetUsersQuery, UserListDTO>
    {
        private readonly IChatDatabaseContext _context;

        public GetUsersQueryHandler(IChatDatabaseContext context)
        {
            _context = context;
        }

        public async Task<UserListDTO> Handle(GetUsersQuery request, CancellationToken cancellationToken)
        {
            var userList = _context.Users
                .OrderBy(x => x.Username)
                .Select(x => new UserDTO
                {
                    Id = x.Id,
                    Email = x.Email,
                    Username = x.Username

                }).ToList();

            return new UserListDTO { Users = userList };
        }
    }
}
