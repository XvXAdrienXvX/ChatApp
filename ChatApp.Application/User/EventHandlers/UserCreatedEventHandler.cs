﻿using ChatApp.Domain.Events;
using MediatR;
using Microsoft.Extensions.Logging;

namespace ChatApp.Application.User.EventHandlers
{
    public class UserCreatedEventHandler : INotificationHandler<UserCreatedEvent>
    {
        private readonly ILogger<UserCreatedEventHandler> _logger;
        public UserCreatedEventHandler(ILogger<UserCreatedEventHandler> logger)
        {
            _logger = logger;
        }

        public Task Handle(UserCreatedEvent notification, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Domain Event: {DomainEvent}", notification.GetType().Name);
            return Task.CompletedTask;
        }
    }
}
