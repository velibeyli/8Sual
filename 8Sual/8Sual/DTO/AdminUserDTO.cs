using _8Sual.Model.Admin;

namespace _8Sual.DTO
{
    public class AdminUserDTO
    {
        public AdminUserDTO(AdminUser adminUser)
        {
            Password = adminUser.Password;
            Username = adminUser.Username;
        }
        public string Username { get; set; }
        public string Password { get; set; }
        public AdminUserDTO()
        {

        }
    }
}
