using _8Sual.Model;
using _8Sual.Repositories.Interfaces;
using _8Sual.Services.Interfaces;

namespace _8Sual.Services.Implementations
{
    public class QuestionService : IQuestionService
    {
        private readonly IQuestionRepository _repo;
        public QuestionService(IQuestionRepository repo)
        {
            _repo = repo;
        }

        public async Task<Question> Create(Question question)
        {
            var result = await _repo.GetAll(x => x.Content == question.Content);
            if (result.Count > 0)
                throw new Exception("Databazada bu sual movcuddur");

            return await  _repo.Create(question);            
        }

        public async Task<IEnumerable<Question>> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<Question> GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
