using _8Sual.DTO;
using _8Sual.Wrappers;

namespace _8Sual.Services.Interfaces
{
    public interface IQuestionService
    {
        Task<ServiceResponse<IEnumerable<QuestionDTO>>> GetAll();
        Task<ServiceResponse<QuestionDTO>> Create(QuestionDTO questionDto);
        Task<ServiceResponse<QuestionDTO>> GetById(int id);
    }
}
