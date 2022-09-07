using _8Sual.DTO;
using _8Sual.Wrappers;

namespace _8Sual.Services.Interfaces
{
    public interface ILoginService
    {
        Task<ServiceResponse<UserDTO>> Login(UserDTO userDto);
    }
}
