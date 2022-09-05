using _8Sual.Db;
using _8Sual.Model;
using _8Sual.Repositories.Interfaces;

namespace _8Sual.Repositories.Implementations
{
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(QuestionContext context) : base(context)
        {
        }
    }
}
