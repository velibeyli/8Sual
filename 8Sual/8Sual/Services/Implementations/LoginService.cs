using _8Sual.DTO;
using _8Sual.Repositories.Interfaces;
using _8Sual.Services.Interfaces;
using _8Sual.Wrappers;

namespace _8Sual.Services.Implementations
{
    public class LoginService : ILoginService
    {
        private readonly IUserRepository _userRepository;
        public LoginService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<ServiceResponse<UserDTO>> Login(UserDTO userDto)
        {
            var result = await _userRepository.GetByFilter(x => x.Username == userDto.Username && x.Password == userDto.Password);
            if (result is null)
            {
                return new ServiceResponse<UserDTO>(null) { Message = "Username or password not valid" };
            }

            var userDtos = new UserDTO(result);

            return new ServiceResponse<UserDTO>(userDtos) { Message = "operation successfully done" };

        }
    }
}
