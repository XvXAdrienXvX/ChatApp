using ChatApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ChatApp.Application.Common.Interfaces
{
    public interface IChatDatabaseContext
    {
        DbSet<Users> Users { get; }
        DbSet<Groups> Groups { get; }
        DbSet<UserGroup> UserGroup { get; }
        DbSet<Message> Message { get; }
        DbSet<MessageRecipient> MessageRecipient { get; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
