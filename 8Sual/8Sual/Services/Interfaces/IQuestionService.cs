using _8Sual.Model;
using _8Sual.RequestModel;

namespace _8Sual.Services.Interfaces
{
    public interface IQuestionService
    {
        Task<IEnumerable<Question>> GetAll();
        Task<Question> Create(QuestionRequestModel question);
        Task<Question> GetById(int id);
    }
}
