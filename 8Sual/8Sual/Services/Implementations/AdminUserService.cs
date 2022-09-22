using _8Sual.DTO;
using _8Sual.Model.Admin;
using _8Sual.Repositories.Interfaces;
using _8Sual.Services.Interfaces;
using _8Sual.Wrappers;
using AutoMapper;

namespace _8Sual.Services.Implementations
{
    public class AdminUserService : IAdminUserService
    {
        private readonly IAdminUserRepository _repo;
        private readonly IMapper _mapper;
        public AdminUserService(IAdminUserRepository repo,IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<AdminUserDTO>> Create(AdminUserDTO adminUserDto)
        {
            AdminUser adminUser = new AdminUser()
            {
                Username = adminUserDto.Username,
                Password = adminUserDto.Password
            };

            var admin = await _repo.Create(adminUser);
            var adminDto = _mapper.Map<AdminUserDTO>(admin);
            return new ServiceResponse<AdminUserDTO>(adminDto) { Message = "Successfully created Admin",StatusCode = 2001};
        }

        public async Task<ServiceResponse<AdminUserDTO>> DeleteById(int id)
        {
            var res = await _repo.GetByFilter(x => x.Id == id);
            if (res is null)
            {
                return new ServiceResponse<AdminUserDTO>(null)
                { Message = "Admin not found",StatusCode = 4000 };
            }

            var deletedUser = await _repo.Delete(res);
            var deletedUserDto = _mapper.Map<AdminUserDTO>(deletedUser);
            return new ServiceResponse<AdminUserDTO>(deletedUserDto)
            { Message = "Successfully deleted admin",StatusCode = 2000};
        }

        public async Task<ServiceResponse<IEnumerable<AdminUserDTO>>> GetAll()
        {
            List<AdminUser> admins = await _repo.GetAll();
            var data = admins.Select(x => _mapper.Map<AdminUserDTO>(x)).ToList();
            return new ServiceResponse<IEnumerable<AdminUserDTO>>(data) { Message = "Data query success", StatusCode = 2000 };
        }

        public async Task<ServiceResponse<AdminUserDTO>> GetById(int id)
        {
            var result = await _repo.GetByFilter(x => x.Id == id);
            if (result is null)
            {
                return new ServiceResponse<AdminUserDTO>(null)
                { Message = "Admin not found", StatusCode = 4000 };
            }

            var resultDto = _mapper.Map<AdminUserDTO>(result);
            return new ServiceResponse<AdminUserDTO>(resultDto)
            { Message = "Successfully operation",StatusCode = 2000};
        }

        public async Task<ServiceResponse<AdminUserDTO>> Update(int id, AdminUserDTO adminUserDto)
        {
            var result = await _repo.GetByFilter(x => x.Id == id);
            if (result is null)
            {
                return new ServiceResponse<AdminUserDTO>(null)
                { Message = "Admin not found", StatusCode = 4000 };
            }

            AdminUser admin = new AdminUser()
            {
                Id = id,
                Username = adminUserDto.Username,
                Password = adminUserDto.Password
            };

            var updatedAdmin = await _repo.Update(admin);
            var updatedAdminDto = _mapper.Map<AdminUserDTO>(result);

            return new ServiceResponse<AdminUserDTO>(updatedAdminDto)
            {Message = "Successfully updated admin",StatusCode = 2001 };
        }
    }
}
