using _8Sual.Model;
using _8Sual.Model.Admin;

namespace _8Sual.Services.Interfaces
{
    public interface IAdminUserService
    {
        Task<IEnumerable<AdminUser>> GetAll();
        Task<AdminUser> DeleteById(int id);
        Task<AdminUser> Create(AdminUser adminUser);
        Task<AdminUser> Update(int id,AdminUser adminUser);
        Task<AdminUser> GetById(int id);
    }
}
