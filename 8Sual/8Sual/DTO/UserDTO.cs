using _8Sual.Model;

namespace _8Sual.DTO
{
    public class UserDTO
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public UserDTO(User user)
        {
            Name = user.Name;
            Surname = user.Surname;
            Username = user.Username;
            Password = user.Password;
        }
    }
}
