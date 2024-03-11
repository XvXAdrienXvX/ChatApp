using AuthGateway.Domain;
using Microsoft.EntityFrameworkCore;

namespace AuthGateway.Database
{
    public interface IAuthDatabaseContext
    {
        DbSet<Users> Users { get; }
        DbSet<Roles> Roles { get; }
        DbSet<Permission> Permission { get; }
        DbSet<RolePermission> RolePermission { get; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
