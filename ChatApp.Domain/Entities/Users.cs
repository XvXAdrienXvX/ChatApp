using ChatApp.Domain.Common;

namespace ChatApp.Domain.Entities
{
    public class Users : BaseEntity
    {
        public int Id { get; set; }

        public string Username { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

    }
}
