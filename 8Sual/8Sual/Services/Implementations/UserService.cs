using _8Sual.DTO;
using _8Sual.Model;
using _8Sual.Repositories.Interfaces;
using _8Sual.Services.Interfaces;
using _8Sual.Wrappers;

namespace _8Sual.Services.Implementations
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repo;
        public UserService(IUserRepository repo)
        {
            _repo = repo;
        }

        public async Task<UserDTO> Create(UserDTO userDto)
        {
            var result = await _repo.GetAll(x => x.Username == userDto.Username);
            if (result.Count > 0)
                throw new Exception("There is already such user with this Username in database.");

            User user = new User()
            {
                Name = userDto.Name,
                Surname = userDto.Surname,
                Username = userDto.Username,
                Password = userDto.Password
            };

            var createdUser = await _repo.Create(user);
            return new UserDTO(createdUser);
        }

        public async Task<UserDTO> Delete(int id)
        {
            var result = await _repo.GetById(x => x.Id == id);
            if (result is null)
                throw new Exception("There is not any user with this id in database");

            var deletedUser = await _repo.Delete(result);
            return new UserDTO(deletedUser);
        }

        public async Task<UserDTO> GetById(int id)
        {
            var result = await _repo.GetById(x => x.Id == id);
            if (result is null)
                throw new Exception("There is not any user with this id in database");

            return new UserDTO(result);
        }

        public async Task<ServiceResponse<IEnumerable<UserDTO>>> GetAll()
        {
            List<User> users = await _repo.GetAll();
            List<UserDTO> userDtos = users.Select(x => new UserDTO(x)).ToList();
            return new ServiceResponse<IEnumerable<UserDTO>>(userDtos)
            { Message = "Data Query Success",StatusCode = 2000 };
        }

        public async Task<UserDTO> Update(int id, UserDTO userDto)
        {
            var result = await _repo.GetById(x => x.Id == id);
            if (result is null)
                throw new Exception("There is not any user with this id in database");

            User user = new User()
            {
                Name = userDto.Name,
                Surname = userDto.Surname,
                Username = userDto.Username,
                Password = userDto.Password
            };

            var updatedUser = await _repo.Update(user);
            return new UserDTO(updatedUser);
        }
    }
}
