using _8Sual.DTO;
using _8Sual.Services.Interfaces;
using _8Sual.Wrappers;
using Microsoft.AspNetCore.Mvc;

namespace _8Sual.Controllers.Admin
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminUserController : ControllerBase
    {
        private readonly IAdminUserService _service;
        public AdminUserController(IAdminUserService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<IEnumerable<AdminUserDTO>>>> GetAll() =>
             Ok(await _service.GetAll());

        [HttpPost("create")]
        public async Task<ActionResult<ServiceResponse<AdminUserDTO>>> CreateUser(AdminUserDTO adminUserDto) =>
            Ok(await _service.Create(adminUserDto));

        [HttpPost("update")]
        public async Task<ActionResult<ServiceResponse<AdminUserDTO>>> UpdateUser(int id, [FromBody] AdminUserDTO adminUserDto) =>
            Ok(await _service.Update(id, adminUserDto));

        [HttpPost("delete")]
        public async Task<ActionResult<ServiceResponse<AdminUserDTO>>> DeleteUser(int id) =>
             Ok(await _service.DeleteById(id));

        [HttpGet("getById")]
        public async Task<ActionResult<ServiceResponse<AdminUserDTO>>> GetUserById(int id) =>
            Ok(await _service.GetById(id));
    }
}
