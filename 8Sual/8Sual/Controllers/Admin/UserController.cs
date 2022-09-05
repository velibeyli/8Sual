using _8Sual.DTO;
using _8Sual.Services.Interfaces;
using _8Sual.Wrappers;
using Microsoft.AspNetCore.Http;
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
        public async Task<ActionResult<UserDTO>> GetById(int id) =>
            Ok(await _service.GetById(id));

        [HttpPost]
        public async Task<ActionResult<UserDTO>> Create(UserDTO userDto) =>
            Ok(await _service.Create(userDto));

        [HttpPut]
        public async Task<ActionResult<UserDTO>> Update(int id, UserDTO userDto) =>
            Ok(await _service.Update(id,userDto));

        [HttpDelete]
        public async Task<ActionResult<UserDTO>> Delete(int id) =>
            Ok(await _service.Delete(id));
    }
}
