using _8Sual.DTO;
using _8Sual.Model;
using _8Sual.Model.Admin;
using _8Sual.Wrappers;

namespace _8Sual.Services.Interfaces
{
    public interface IAdminUserService
    {
        Task<ServiceResponse<IEnumerable<AdminUserDTO>>> GetAll();
        Task<AdminUserDTO> DeleteById(int id);
        Task<AdminUserDTO> Create(AdminUserDTO adminUser);
        Task<AdminUserDTO> Update(int id,AdminUserDTO adminUserDto);
        Task<AdminUserDTO> GetById(int id);
    }
}
