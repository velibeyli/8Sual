using _8Sual.DTO;
using _8Sual.Wrappers;

namespace _8Sual.Services.Interfaces
{
    public interface IUserService
    {
        Task<ServiceResponse<IEnumerable<UserDTO>>> GetAll();
        Task<ServiceResponse<UserDTO>> GetById(int id);
        Task<ServiceResponse<UserDTO>> Register(UserDTO userDto);
        Task<ServiceResponse<UserDTO>> Delete(int id);
    }
}
