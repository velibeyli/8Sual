﻿using _8Sual.DTO;
using _8Sual.Model;
using _8Sual.Repositories.Interfaces;
using _8Sual.Services.Interfaces;
using _8Sual.Wrappers;
using AutoMapper;

namespace _8Sual.Services.Implementations
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repo;
        private readonly IMapper _mapper;
        public UserService(IUserRepository repo,IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<UserDTO>> Register(UserDTO userDto)
        {
            User result = await _repo.GetByFilter(x => x.Username == userDto.Username);
            UserDTO resultDto = _mapper.Map<UserDTO>(result);

            if (result is not null)
            {
                return new ServiceResponse<UserDTO>(resultDto) { Message = "There is such user with this username in database", StatusCode = 4000 };
            }

            User user = new User()
            {
                Username = userDto.Username,
                Password = userDto.Password
            };

            var createdUser = await _repo.Create(user);
            var createdUserDto = _mapper.Map<UserDTO>(createdUser);
            return new ServiceResponse<UserDTO>(createdUserDto) { Message = "User successfully created", StatusCode = 2001 };
        }

        public async Task<ServiceResponse<UserDTO>> Delete(int id)
        {
            User result = await _repo.GetByFilter(x => x.Id == id);
            if (result is null)
            {
                return new ServiceResponse<UserDTO>(null) 
                { Message = "User not found", StatusCode = 4000 };
            }

            var deletedUser = await _repo.Delete(result);
            var deletedUserDto = _mapper.Map<UserDTO>(deletedUser);
            return new ServiceResponse<UserDTO>(deletedUserDto) { Message = "User successfully deleted", StatusCode = 2000 };
        }

        public async Task<ServiceResponse<UserDTO>> GetById(int id)
        {
            var result = await _repo.GetByFilter(x => x.Id == id);
            if (result is null)
            {
                return new ServiceResponse<UserDTO>(null)
                { Message = "User not found", StatusCode = 4000 };
            }

            var resultDto = _mapper.Map<UserDTO>(result);
            return new ServiceResponse<UserDTO>(resultDto) { Message = "Successfully operation", StatusCode = 2000 };
        }

        public async Task<ServiceResponse<IEnumerable<UserDTO>>> GetAll()
        {
            List<User> users = await _repo.GetAll();
            List<UserDTO> userDtos = users.Select(x => _mapper.Map<UserDTO>(x)).ToList();
            return new ServiceResponse<IEnumerable<UserDTO>>(userDtos)
            { Message = "Data Query Success", StatusCode = 2000 };
        }

    }
}
