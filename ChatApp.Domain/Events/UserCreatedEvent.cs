using ChatApp.Domain.Common;
using ChatApp.Domain.Entities;

namespace ChatApp.Domain.Events
{
    public class UserCreatedEvent : BaseEvent
    {
        public Users User { get; }

        public UserCreatedEvent(Users user)
        {
            User = user;
        }
    }
}
