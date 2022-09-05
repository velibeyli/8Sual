using _8Sual.DTO;
using _8Sual.Model;
using _8Sual.Repositories.Interfaces;
using _8Sual.Services.Interfaces;
using _8Sual.Wrappers;

namespace _8Sual.Services.Implementations
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _repo;
        public CategoryService(ICategoryRepository repo)
        {
            _repo = repo;
        }

        public async Task<CategoryDTO> Create(CategoryDTO categoryDto)
        {
            var result = await _repo.GetAll(x => x.Name == categoryDto.Name);
            if (result.Count > 0)
                throw new Exception("There is already this category  in database");

            Category category = new Category()
            {
                Name = categoryDto.Name,
                Score = categoryDto.Score
            };

            var createdCategory = await _repo.Create(category);
            return new CategoryDTO(createdCategory);
        }

        public async Task<CategoryDTO> Delete(int id)
        {
            var result = await _repo.GetById(x => x.Id == id);
            if (result is null)
                throw new Exception("Category not found");

            var deletedCategory = await _repo.Delete(result);
            return new CategoryDTO(deletedCategory);
        }

        public async Task<ServiceResponse<IEnumerable<CategoryDTO>>> GetAll()
        {
            List<Category> categories = await _repo.GetAll();
            List<CategoryDTO> categoryDtos = categories.Select(x => new CategoryDTO(x)).ToList();
            return new ServiceResponse<IEnumerable<CategoryDTO>>(categoryDtos)
            {Message = "Data query success",StatusCode = 2000 };
        }

        public async Task<CategoryDTO> GetById(int id)
        {
            var result = await _repo.GetById(x => x.Id == id);
            if (result is null)
                throw new Exception("Category not found");

            return new CategoryDTO(result);
        }

        public async Task<CategoryDTO> Update(int id, CategoryDTO categoryDto)
        {
            var result = await _repo.GetById(x => x.Id == id);
            if (result is null)
                throw new Exception("Category not found");

            Category category = new Category()
            {
                Name = categoryDto.Name,
                Score = categoryDto.Score
            };
             
            var updatedCategory = await _repo.Create(category);
            return new CategoryDTO(updatedCategory);
        }
    }
}
