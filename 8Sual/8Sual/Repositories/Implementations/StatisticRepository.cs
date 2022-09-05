using _8Sual.Db;
using _8Sual.Model.Admin;
using _8Sual.Repositories.Interfaces;

namespace _8Sual.Repositories.Implementations
{
    public class StatisticRepository : GenericRepository<Statistic>, IStatisticRepository
    {
        public StatisticRepository(QuestionContext context) : base(context)
        {
        }
    }
}
