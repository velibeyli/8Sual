using _8Sual.Model;
using _8Sual.Model.Admin;
using Microsoft.EntityFrameworkCore;

namespace _8Sual.Db
{
    public class QuestionContext : DbContext
    {
        public QuestionContext(DbContextOptions<QuestionContext> options) 
            : base(options)
        {

        }
        public DbSet<AdminUser> AdminUser { get; set; }
        public DbSet<Statistic> Statistic { get; set; }
        public DbSet<Winner> Winner { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<Question> Question { get; set; }
        public DbSet<QuestionAnswer> QuestionAnswer { get; set; }

    }
}
