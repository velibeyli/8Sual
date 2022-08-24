using _8Sual.Model;
using _8Sual.RequestModel;
using _8Sual.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace _8Sual.Controllers.Admin
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionController : ControllerBase
    {
        private readonly IQuestionService _service;
        public QuestionController(IQuestionService service)
        {
            _service = service;
        }

        [HttpPost("create")]
        public async Task<ActionResult<Question>> Create(QuestionRequestModel request) =>
            Ok(await _service.Create(request));
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Question>>> GetAll() =>
            Ok(await _service.GetAll());
        [HttpGet("getById")]
        public async Task<ActionResult<Question>> GetById(int id) =>
            Ok(await _service.GetById(id));
    }
}
