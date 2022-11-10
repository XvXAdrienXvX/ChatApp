using ChatApp.Application.Common.Interfaces;
using ChatApp.Infrastructure.Persistence;
using ChatApp.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ChatApp.Infrastructure
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddDbContext<ChatDatabaseContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
                    builder => builder.MigrationsAssembly(typeof(ChatDatabaseContext).Assembly.FullName)));

            services.AddScoped<IChatDatabaseContext>(provider => provider.GetRequiredService<ChatDatabaseContext>());
            services.AddScoped<ITokenService, TokenService>();

            return services;
        }
    }
}
