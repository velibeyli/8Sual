using _8Sual.Model.Admin;
using Microsoft.EntityFrameworkCore;

namespace _8Sual.Db
{
    public class QuestionContext : DbContext
    {
        public QuestionContext(DbContextOptions options) 
            : base(options)
        {

        }
        public DbSet<AdminUser> AdminUser { get; set; }
    }
}
