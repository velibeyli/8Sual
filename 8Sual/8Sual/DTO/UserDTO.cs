using _8Sual.Model;

namespace _8Sual.DTO
{
    public class UserDTO
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public UserDTO(User user)
        {
            Username = user.Username;
            Password = user.Password;
        }
        public UserDTO()
        {

        }
    }
}
