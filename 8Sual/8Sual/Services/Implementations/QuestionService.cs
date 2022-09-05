using _8Sual.DTO;
using _8Sual.Model;
using _8Sual.Repositories.Interfaces;
using _8Sual.RequestModel;
using _8Sual.Services.Interfaces;
using _8Sual.Wrappers;

namespace _8Sual.Services.Implementations
{
    public class QuestionService : IQuestionService
    {
        private readonly IQuestionRepository _repo;
        public QuestionService(IQuestionRepository repo)
        {
            _repo = repo;
        }

        public async Task<QuestionDTO> Create(QuestionDTO questionDto)
        {
            var result = await _repo.GetAll(x => x.Content == questionDto.Content);
            if (result.Count > 0)
                throw new Exception("Databazada bu sual movcuddur");

            QuestionAnswer answer = new QuestionAnswer()
            {
                AnswerContent = questionDto.AnswerContent
            };


            Question quest = new Question()
            {
                Content = questionDto.Content,
                FirstAnswer = questionDto.FirstAnswer,
                SecondAnswer = questionDto.SecondAnswer,
                ThirdAnswer = questionDto.ThirdAnswer,
                FourthAnswer = questionDto.FourthAnswer,
                CategoryId = questionDto.CategoryId,
                Answer = answer
            };

            var createdQuestion = await _repo.Create(quest);
            return new QuestionDTO(createdQuestion);
        }

        public async Task<ServiceResponse<IEnumerable<QuestionDTO>>> GetAll()
        {
            List<Question> questions = await _repo.GetAll();
            List<QuestionDTO> questionsDto = questions.Select(x => new QuestionDTO(x)).ToList();
            return new ServiceResponse<IEnumerable<QuestionDTO>>(questionsDto)
            { Message = "Data query success", StatusCode = 2000 };
        }

        public async Task<QuestionDTO> GetById(int id)
        {
            var result = await _repo.GetById(x => x.Id == id);
            if (result is null)
                throw new Exception("Question not found");

            return new QuestionDTO(result);
        }
    }
}
