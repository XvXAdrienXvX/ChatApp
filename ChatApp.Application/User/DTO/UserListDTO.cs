namespace ChatApp.Application.User.DTO
{
    public class UserListDTO
    {
        public List<UserDTO> Users { get; set; } = new List<UserDTO>();
    }

    public class UserDTO
    {
        public int Id { get; set; }

        public string Username { get; set; }

        public string Email { get; set; }
    }
}
