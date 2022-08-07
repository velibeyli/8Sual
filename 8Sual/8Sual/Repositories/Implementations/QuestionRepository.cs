using _8Sual.Db;
using _8Sual.Model;
using _8Sual.Repositories.Interfaces;

namespace _8Sual.Repositories.Implementations
{
    public class QuestionRepository : GenericRepository<Question>,IQuestionRepository
    {
        public QuestionRepository(QuestionContext context) : base(context) { }
    }
}
