using ChatApp.Application.Common.Interfaces;
using ChatApp.Domain.Entities;
using ChatApp.Infrastructure.Extensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace ChatApp.Infrastructure.Persistence
{
    public class ChatDatabaseContext : DbContext, IChatDatabaseContext
    {
        private readonly IMediator _mediator;
        public ChatDatabaseContext(IMediator mediator, DbContextOptions options) : base(options)
        {
            _mediator = mediator;
        }
        public DbSet<Users> Users => Set<Users>();

        public DbSet<Groups> Groups => Set<Groups>();

        public DbSet<UserGroup> UserGroup => Set<UserGroup>();

        public DbSet<Message> Message => Set<Message>();

        public DbSet<MessageRecipient> MessageRecipient => Set<MessageRecipient>();

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(builder);
        }

        public async Task<int> SaveChangesAsync(CancellationToken cancellationToken)
        {
            await _mediator.DispatchDomainEvents(this);

            return await base.SaveChangesAsync(cancellationToken);
        }
    }
}
