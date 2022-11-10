using ChatApp.Domain.Common;
using ChatApp.Domain.Entities;

namespace ChatApp.Domain.Events
{
    public class UserLoggedInEvent : BaseEvent
    {
        public Users User { get; }

        public UserLoggedInEvent(Users user)
        {
            User = user;
        }
    }
}
