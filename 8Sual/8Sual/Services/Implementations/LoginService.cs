using _8Sual.DTO;
using _8Sual.Repositories.Interfaces;
using _8Sual.Services.Interfaces;
using _8Sual.Validation;
using _8Sual.Wrappers;
using AutoMapper;
using FluentValidation;

namespace _8Sual.Services.Implementations
{
    public class LoginService : ILoginService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        public LoginService(IUserRepository userRepository,IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }
        public async Task<ServiceResponse<UserDTO>> Login(UserDTO userDto)
        {
            UserValidator validator = new UserValidator();
            await validator.ValidateAndThrowAsync(userDto);  

            var result = await _userRepository.GetByFilter(x => x.Username == userDto.Username && x.Password == userDto.Password);
            if (result is null)
            {
                return new ServiceResponse<UserDTO>(null) { Message = "Username or password not valid" };
            }

            var userDtos = _mapper.Map<UserDTO>(result);

            return new ServiceResponse<UserDTO>(userDtos) { Message = "operation successfully done" };

        }
    }
}
