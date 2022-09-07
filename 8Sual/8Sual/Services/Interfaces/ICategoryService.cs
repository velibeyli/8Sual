using _8Sual.DTO;
using _8Sual.Wrappers;

namespace _8Sual.Services.Interfaces
{
    public interface ICategoryService
    {
        Task<ServiceResponse<IEnumerable<CategoryDTO>>> GetAll();
        Task<ServiceResponse<CategoryDTO>> GetById(int id);
        Task<ServiceResponse<CategoryDTO>> Create(CategoryDTO categoryDto);
        Task<ServiceResponse<CategoryDTO>> Update(int id, CategoryDTO categoryDto);
        Task<ServiceResponse<CategoryDTO>> Delete(int id);
    }
}
