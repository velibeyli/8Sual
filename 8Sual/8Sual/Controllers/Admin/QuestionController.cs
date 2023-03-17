using _8Sual.DTO;
using _8Sual.Services.Interfaces;
using _8Sual.Wrappers;
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
        public async Task<ActionResult<ServiceResponse<QuestionDTO>>> Create(QuestionDTO questionDto) =>
            Ok(await _service.Create(questionDto));

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<IEnumerable<QuestionDTO>>>> GetAll() =>
            Ok(await _service.GetAll());

        [HttpGet("getById")]
        public async Task<ActionResult<ServiceResponse<QuestionDTO>>> GetById(int id) =>
            Ok(await _service.GetById(id));

        [HttpPut("update")]
        public async Task<ActionResult<ServiceResponse<QuestionDTO>>> Update(int id, QuestionDTO questionDTO) =>
            Ok(await _service.Update(id,questionDTO));

        [HttpDelete("delete")]
        public async Task<ActionResult<ServiceResponse<QuestionDTO>>> Delete(int id)=>
            Ok(await _service.Delete(id));

        // TODO: implement delete and update method (solved)


    }
}
