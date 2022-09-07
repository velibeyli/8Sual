using _8Sual.DTO;
using _8Sual.Services.Interfaces;
using _8Sual.Wrappers;
using Microsoft.AspNetCore.Mvc;

namespace _8Sual.Controllers.Admin
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatisticController : ControllerBase
    {
        private readonly IStatisticService _service;
        public StatisticController(IStatisticService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<IEnumerable<StatisticDTO>>>> GetAll() =>
            Ok(await _service.GetAll());

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<StatisticDTO>>> GetById(int id) =>
            (await _service.GetById(id));

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<StatisticDTO>>> Create(StatisticDTO statisticDto) =>
            Ok(await _service.Create(statisticDto));
    }
}
