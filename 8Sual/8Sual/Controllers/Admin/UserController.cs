using _8Sual.DTO;
using _8Sual.Services.Interfaces;
using _8Sual.Wrappers;
using Microsoft.AspNetCore.Mvc;

namespace _8Sual.Controllers.Admin
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _service;
        public UserController(IUserService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<IEnumerable<UserDTO>>>> GetAll() =>
            Ok(await _service.GetAll());

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<UserDTO>>> GetById(int id) =>
            Ok(await _service.GetById(id));

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<UserDTO>>> Create(UserDTO userDto) =>
            Ok(await _service.Register(userDto));


        [HttpDelete]
        public async Task<ActionResult<ServiceResponse<UserDTO>>> Delete(int id) =>
            Ok(await _service.Delete(id));
    }
}
