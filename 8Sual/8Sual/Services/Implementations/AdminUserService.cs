using _8Sual.Model;
using _8Sual.Model.Admin;
using _8Sual.Repositories.Interfaces;
using _8Sual.Services.Interfaces;

namespace _8Sual.Services.Implementations
{
    public class AdminUserService : IAdminUserService
    {
        private readonly IAdminUserRepository _repo;
        public AdminUserService(IAdminUserRepository repo)
        {
            _repo = repo;
        }

        public async Task<AdminUser> Create(AdminUser adminUser)
        {
            return await _repo.Create(adminUser);
        }

        public async Task<AdminUser> DeleteById(int id)
        {
            var res = await _repo.GetById(x => x.Id == id);
            if (res is null)
                throw new Exception("User not found");

            var deletedUser = await _repo.Delete(res);
            return deletedUser;
        }

        public async Task<IEnumerable<AdminUser>> GetAll()
        {
            return await _repo.GetAll();
        }

        public async Task<AdminUser> GetById(int id)
        {
            var result = await _repo.GetById(x => x.Id == id);
            if (result is null)
                throw new Exception("User not found");
            return result;
        }

        public async Task<AdminUser> Update(int id, AdminUser adminUser)
        {
            var result = await _repo.GetById(x => x.Id == id);
            if (result is null)
                throw new Exception("User not found");

            result.Username = adminUser.Username;
            result.Password = adminUser.Password;

            return await _repo.Update(result);
        }
    }
}
