using _8Sual.Model;
using _8Sual.Repositories.Interfaces;
using _8Sual.RequestModel;
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

        public async Task<Question> Create(QuestionRequestModel question)
        {
            var result = await _repo.GetAll(x => x.Content == question.Content);
            if (result.Count > 0)
                throw new Exception("Databazada bu sual movcuddur");
            QuestionAnswer answer = new QuestionAnswer()
            {
                AnswerContent = question.AnswerContent
            };


            Question quest = new Question()
            {
                Content = question.Content,
                FirstAnswer = question.FirstAnswer,
                SecondAnswer = question.SecondAnswer,
                ThirdAnswer = question.ThirdAnswer,
                FourthAnswer = question.FourthAnswer,
                CategoryId = question.CategoryId,
                Answer = answer                
            };
            return await  _repo.Create(quest);            
        }

        public async Task<IEnumerable<Question>> GetAll()
        {
            return await _repo.GetAll();
        }

        public async Task<Question> GetById(int id)
        {
            var result = await _repo.GetById(x => x.Id == id);
            if (result is null)
                throw new Exception("Question not found");
            return result;
        }
    }
}
