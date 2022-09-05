using _8Sual.DTO;
using _8Sual.Model;
using _8Sual.RequestModel;
using _8Sual.Wrappers;

namespace _8Sual.Services.Interfaces
{
    public interface IQuestionService
    {
        Task<ServiceResponse<IEnumerable<QuestionDTO>>> GetAll();
        Task<QuestionDTO> Create(QuestionDTO questionDto);
        Task<QuestionDTO> GetById(int id);
    }
}
