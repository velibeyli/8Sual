using _8Sual.DTO;
using _8Sual.Wrappers;

namespace _8Sual.Services.Interfaces
{
    public interface IAdminUserService
    {
        Task<ServiceResponse<IEnumerable<AdminUserDTO>>> GetAll();
        Task<ServiceResponse<AdminUserDTO>> DeleteById(int id);
        Task<ServiceResponse<AdminUserDTO>> Create(AdminUserDTO adminUser);
        Task<ServiceResponse<AdminUserDTO>> Update(int id, AdminUserDTO adminUserDto);
        Task<ServiceResponse<AdminUserDTO>> GetById(int id);
    }
}
