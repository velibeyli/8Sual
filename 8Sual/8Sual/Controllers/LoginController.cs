﻿using _8Sual.DTO;
using _8Sual.Model;
using _8Sual.Services.Interfaces;
using _8Sual.Wrappers;
using Microsoft.AspNetCore.Mvc;

namespace _8Sual.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ILoginService _service;
        public LoginController(ILoginService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<UserDTO>>> Login([FromQuery] UserDTO userDto) =>
            Ok(await _service.Login(userDto));

        [HttpGet("showQuestions")]
        public async Task<ActionResult<ServiceResponse<List<Question>>>> ShowQuestions() =>
            Ok(await _service.ShowQuestions());


    }
}
