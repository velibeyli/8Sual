using _8Sual.Model;

namespace _8Sual.Services.Interfaces
{
    public interface IQuestionService
    {
        Task<IEnumerable<Question>> GetAll();
        Task<Question> Create(Question question);
        Task<Question> GetById(int id);
    }
}
