using _8Sual.DTO;
using _8Sual.Model;
using _8Sual.Model.Admin;
using _8Sual.Repositories.Interfaces;
using _8Sual.Services.Interfaces;
using _8Sual.Wrappers;

namespace _8Sual.Services.Implementations
{
    public class AdminUserService : IAdminUserService
    {
        private readonly IAdminUserRepository _repo;
        public AdminUserService(IAdminUserRepository repo)
        {
            _repo = repo;
        }

        public async Task<AdminUserDTO> Create(AdminUserDTO adminUserDto)
        {
            AdminUser adminUser = new AdminUser()
            {
                Username = adminUserDto.Username,
                Password = adminUserDto.Password
            };

            var admin = await _repo.Create(adminUser);
            return new AdminUserDTO(admin);
        }

        public async Task<AdminUserDTO> DeleteById(int id)
        {
            var res = await _repo.GetById(x => x.Id == id);
            if (res is null)
                throw new Exception("User not found");

            var deletedUser = await _repo.Delete(res);
            return new AdminUserDTO(deletedUser);
        }

        public async Task<ServiceResponse<IEnumerable<AdminUserDTO>>> GetAll()
        {
            List<AdminUser> admins = await _repo.GetAll();
            var data = admins.Select(x => new AdminUserDTO(x)).ToList();
            return new ServiceResponse<IEnumerable<AdminUserDTO>>(data) { Message = "Data query success",StatusCode = 2000};
        }

        public async Task<AdminUserDTO> GetById(int id)
        {
            var result = await _repo.GetById(x => x.Id == id);
            if (result is null)
                throw new Exception("User not found");

            return new AdminUserDTO(result);
        }

        public async Task<AdminUserDTO> Update(int id, AdminUserDTO adminUserDto)
        {
            var result = await _repo.GetById(x => x.Id == id);
            if (result is null)
                throw new Exception("User not found");

            AdminUser admin = new AdminUser()
            {
                Username = adminUserDto.Username,
                Password = adminUserDto.Password
            };

            var updatedAdmin = await _repo.Update(admin);

            return new AdminUserDTO(updatedAdmin);
        }
    }
}
