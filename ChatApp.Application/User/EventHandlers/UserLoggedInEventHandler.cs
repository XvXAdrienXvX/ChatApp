using ChatApp.Domain.Events;
using MediatR;
using Microsoft.Extensions.Logging;

namespace ChatApp.Application.User.EventHandlers
{
    public class UserLoggedInEventHandler : INotificationHandler<UserLoggedInEvent>
    {
        private readonly ILogger<UserLoggedInEventHandler> _logger;
        public UserLoggedInEventHandler(ILogger<UserLoggedInEventHandler> logger)
        {
            _logger = logger;
        }

        public Task Handle(UserLoggedInEvent notification, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Domain Event: {DomainEvent}", notification.GetType().Name);
            return Task.CompletedTask;
        }
    }
}
