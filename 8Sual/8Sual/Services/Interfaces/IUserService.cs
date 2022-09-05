using _8Sual.DTO;
using _8Sual.Wrappers;

namespace _8Sual.Services.Interfaces
{
    public interface IUserService
    {
        Task<ServiceResponse<IEnumerable<UserDTO>>> GetAll();
        Task<UserDTO> GetById(int id);
        Task<UserDTO> Create(UserDTO userDto);
        Task<UserDTO> Update(int id,UserDTO userDto);
        Task<UserDTO> Delete(int id);
    }
}
