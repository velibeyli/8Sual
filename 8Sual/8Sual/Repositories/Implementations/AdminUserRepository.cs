using _8Sual.Db;
using _8Sual.Model.Admin;
using _8Sual.Repositories.Interfaces;

namespace _8Sual.Repositories.Implementations
{
    public class AdminUserRepository : GenericRepository<AdminUser>, IAdminUserRepository
    {
        public AdminUserRepository(QuestionContext context) : base(context) { }
    }
}
