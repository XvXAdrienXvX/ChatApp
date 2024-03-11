using AuthGateway.Domain;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace AuthGateway.Database
{
    public class AuthDatabaseContext : DbContext, IAuthDatabaseContext
    {
        public AuthDatabaseContext(DbContextOptions options) : base(options)
        {
                
        }
        public DbSet<Users> Users => Set<Users>();

        public DbSet<Roles> Roles => Set<Roles>();

        public DbSet<Permission> Permission => Set<Permission>();

        public DbSet<RolePermission> RolePermission => Set<RolePermission>();

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(builder);
        }
    }
}
