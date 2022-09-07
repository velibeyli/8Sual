using _8Sual.DTO;
using _8Sual.Services.Interfaces;
using _8Sual.Wrappers;
using Microsoft.AspNetCore.Mvc;

namespace _8Sual.Controllers.Admin
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _service;
        public CategoryController(ICategoryService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<IEnumerable<CategoryDTO>>>> GetAll() =>
            Ok(await _service.GetAll());

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<CategoryDTO>>> GetById(int id) =>
            Ok(await _service.GetById(id));

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<CategoryDTO>>> Create(CategoryDTO categoryDto) =>
            Ok(await _service.Create(categoryDto));

        [HttpPut]
        public async Task<ActionResult<CategoryDTO>> Update(int id, CategoryDTO categoryDto) =>
            Ok(await _service.Update(id, categoryDto));

        [HttpDelete]
        public async Task<ActionResult<CategoryDTO>> Delete(int id) =>
            Ok(await _service.Delete(id));

    }
}
