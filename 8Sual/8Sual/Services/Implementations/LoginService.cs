using _8Sual.Db;
using _8Sual.DTO;
using _8Sual.Model;
using _8Sual.Options;
using _8Sual.Repositories.Interfaces;
using _8Sual.Services.Interfaces;
using _8Sual.Validation;
using _8Sual.Wrappers;
using AutoMapper;
using FluentValidation;
using Microsoft.Extensions.Options;

namespace _8Sual.Services.Implementations
{
    public class LoginService : ILoginService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly IQuestionRepository _questionRepository;
        private readonly QuestionOptions _questionOptions;
        public LoginService(IUserRepository userRepository
            ,IMapper mapper,IQuestionRepository questionRepository,
            IOptions<QuestionOptions> questionOptions)
        {
            _userRepository = userRepository;
            _questionOptions = questionOptions.Value;
            _mapper = mapper;
            _questionRepository = questionRepository;
        }
        public async Task<ServiceResponse<UserDTO>> Login(UserDTO userDto)
        {
            UserValidator validator = new UserValidator();
            await validator.ValidateAndThrowAsync(userDto);  

            var result = await _userRepository.GetByFilter(x => x.Username == userDto.Username && x.Password == userDto.Password);
            if (result is null)
            {
                return new ServiceResponse<UserDTO>(null) { Message = "Username or password not valid" };
            }

            var userDtos = _mapper.Map<UserDTO>(result);

            return new ServiceResponse<UserDTO>(userDtos) { Message = "operation successfully done" };

        }

        public async Task<ServiceResponse<List<Question>>> ShowQuestions()
        {
            List<Question> questions = await _questionRepository.GetAll();
            List<Question> userQuestions = new(capacity: 8);
            Random random = new();

            foreach (var questionType in _questionOptions.QuestionTypes)
            {
                GetQuestion(questionType.Value.CategoryId, questionType.Value.Count);
            }

            void GetQuestion(int categoryId, int count)
            {
                var result = questions
                    .Where(x => x.CategoryId == categoryId)
                    .OrderBy(x => random.Next())
                    .Take(count)
                    .ToList();

                userQuestions.AddRange(result);
            }
            
            return new ServiceResponse<List<Question>>(userQuestions)
            { Message = "Successfully operated", StatusCode = 2000 };

        }
    }
}
