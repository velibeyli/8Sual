using _8Sual.DTO;
using _8Sual.Wrappers;

namespace _8Sual.Services.Interfaces
{
    public interface ICategoryService
    {
        Task<ServiceResponse<IEnumerable<CategoryDTO>>> GetAll();
        Task<CategoryDTO> GetById(int id);
        Task<CategoryDTO> Create(CategoryDTO categoryDto);
        Task<CategoryDTO> Update(int id,CategoryDTO categoryDto);
        Task<CategoryDTO> Delete(int id);
    }
}
