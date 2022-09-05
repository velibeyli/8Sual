using _8Sual.Db;
using _8Sual.Model;
using _8Sual.Repositories.Interfaces;

namespace _8Sual.Repositories.Implementations
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(QuestionContext context) : base(context)
        {
        }
    }
}
