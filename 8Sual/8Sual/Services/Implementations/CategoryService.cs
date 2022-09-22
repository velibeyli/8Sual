using _8Sual.DTO;
using _8Sual.Model;
using _8Sual.Repositories.Interfaces;
using _8Sual.Services.Interfaces;
using _8Sual.Wrappers;
using AutoMapper;

namespace _8Sual.Services.Implementations
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _repo;
        private readonly IMapper _mapper;
        public CategoryService(ICategoryRepository repo,IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<CategoryDTO>> Create(CategoryDTO categoryDto)
        {
            var result = await _repo.GetByFilter(x => x.Name == categoryDto.Name);
            var resultDto = _mapper.Map<CategoryDTO>(result);
            if (result is not null)
            {
                return new ServiceResponse<CategoryDTO>(resultDto)
                { Message = "There is already this category  in database", StatusCode = 4000 };
            }

            Category category = new Category()
            {
                Name = categoryDto.Name,
                Score = categoryDto.Score,
                Questions = categoryDto.Questions
            };

            var createdCategory = await _repo.Create(category);
            var createdCategoryDto = _mapper.Map<CategoryDTO>(createdCategory);
            return new ServiceResponse<CategoryDTO>(createdCategoryDto)
            { Message = "Successfully created category",StatusCode = 2001};
        }

        public async Task<ServiceResponse<CategoryDTO>> Delete(int id)
        {
            var result = await _repo.GetByFilter(x => x.Id == id);
            if (result is null)
            {
                return new ServiceResponse<CategoryDTO>(null)
                { Message = "Category not found",StatusCode = 4000 };
            }
            var deletedCategory = await _repo.Delete(result);
            var deletedCategoryDto = _mapper.Map<CategoryDTO>(deletedCategory);
            return new ServiceResponse<CategoryDTO>(deletedCategoryDto)
            { Message = "Successfully deleted category",StatusCode = 2000};
        }

        public async Task<ServiceResponse<IEnumerable<CategoryDTO>>> GetAll()
        {
            List<Category> categories = await _repo.GetAll();
            List<CategoryDTO> categoryDtos = categories.Select(x => _mapper.Map<CategoryDTO>(x)).ToList();
            return new ServiceResponse<IEnumerable<CategoryDTO>>(categoryDtos)
            { Message = "Data query success", StatusCode = 2000 };
        }

        public async Task<ServiceResponse<CategoryDTO>> GetById(int id)
        {
            var result = await _repo.GetByFilter(x => x.Id == id);
            if (result is null)
            {
                return new ServiceResponse<CategoryDTO>(null)
                { Message = "Category not found", StatusCode = 4000 };
            }

            var resultDto = _mapper.Map<CategoryDTO>(result);
            return new ServiceResponse<CategoryDTO>(resultDto)
            { Message = "Successfully operation",StatusCode = 2000};
        }

        public async Task<ServiceResponse<CategoryDTO>> Update(int id, CategoryDTO categoryDto)
        {
            var result = await _repo.GetByFilter(x => x.Id == id);
            if (result is null)
            {
                return new ServiceResponse<CategoryDTO>(null)
                { Message = "Category not found", StatusCode = 4000 };
            }

            Category category = new Category()
            {
                Name = categoryDto.Name,
                Score = categoryDto.Score
            };

            var updatedCategory = await _repo.Create(category);
            var updatedCategoryDto = _mapper.Map<CategoryDTO>(updatedCategory);
            return new ServiceResponse<CategoryDTO>(updatedCategoryDto)
            { Message = "Successfully updated category",StatusCode = 2000};
        }
    }
}
