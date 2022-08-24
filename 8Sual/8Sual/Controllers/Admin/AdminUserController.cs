using _8Sual.Model;
using _8Sual.Model.Admin;
using _8Sual.Repositories.Interfaces;
using _8Sual.Services.Interfaces;
using Microsoft.AspNetCore.Http;
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
        public async Task<ActionResult<IEnumerable<AdminUser>>> GetAll() =>
             Ok(await _service.GetAll());

        [HttpPost("create")]
        public async Task<ActionResult<AdminUser>> CreateUser(AdminUser adminUser) =>
            Ok(await _service.Create(adminUser));

        [HttpPost("update")]
        public async Task<ActionResult<AdminUser>> UpdateUser(int id, [FromBody] AdminUser adminUser) =>
            Ok(await _service.Update(id, adminUser));

        [HttpPost("delete")]
        public async Task<ActionResult<AdminUser>> DeleteUser(int id) =>
             Ok(await _service.DeleteById(id));

        [HttpGet("getById")]
        public async Task<ActionResult<AdminUser>> GetUserById(int id) =>
            Ok(await _service.GetById(id));
    }
}
