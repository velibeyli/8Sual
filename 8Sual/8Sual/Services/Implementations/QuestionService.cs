using _8Sual.DTO;
using _8Sual.Model;
using _8Sual.Repositories.Interfaces;
using _8Sual.Services.Interfaces;
using _8Sual.Wrappers;
using AutoMapper;

namespace _8Sual.Services.Implementations
{
    public class QuestionService : IQuestionService
    {
        private readonly IQuestionRepository _repo;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;
        public QuestionService(IQuestionRepository repo, ICategoryRepository categoryRepository,IMapper mapper)
        {
            _repo = repo;
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<QuestionDTO>> Create(QuestionDTO questionDto)
        {
            var result = await _repo.GetByFilter(x => x.Content == questionDto.Content);
            
            if (result != null)
            {
                return new ServiceResponse<QuestionDTO>(null)
                { Message = "There is already a question with this content in database", StatusCode = 4000 };
            }
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
            var createdQuestionDto = _mapper.Map<QuestionDTO>(createdQuestion);
            return new ServiceResponse<QuestionDTO>(createdQuestionDto)
            { Message = "Successfully created question",StatusCode = 2001};
        }

        public async Task<ServiceResponse<IEnumerable<QuestionDTO>>> GetAll()
        {
            List<Question> questions = await _repo.GetAll();
            List<QuestionDTO> questionsDto = questions.Select(x => _mapper.Map<QuestionDTO>(x)).ToList();
            return new ServiceResponse<IEnumerable<QuestionDTO>>(questionsDto)
            { Message = "Data query success", StatusCode = 2000 };
        }

        public async Task<ServiceResponse<QuestionDTO>> GetById(int id)
        {
            var result = await _repo.GetByFilter(x => x.Id == id);
            if (result is null)
            {
                return new ServiceResponse<QuestionDTO>(null)
                { Message = "Question not found", StatusCode = 4000 };
            }

            var resultDto = _mapper.Map<QuestionDTO>(result);
            return new ServiceResponse<QuestionDTO>(resultDto)
            { Message = "Successfully operation"};
        }
    }
}
