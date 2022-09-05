using _8Sual.DTO;
using _8Sual.Model.Admin;
using _8Sual.Repositories.Interfaces;
using _8Sual.Services.Interfaces;
using _8Sual.Wrappers;

namespace _8Sual.Services.Implementations
{
    public class StatisticService : IStatisticService
    {
        private readonly IStatisticRepository _repo;
        public StatisticService(IStatisticRepository repo)
        {
            _repo = repo;
        }

        public async Task<StatisticDTO> Create(StatisticDTO statisticDto)
        {
            var result = await _repo.GetAll(x => x.Gamedate == statisticDto.Gamedate);
            if (result.Count > 0)
                throw new Exception("There is no any statistic in this game date in database");

            Statistic statistics = new Statistic()
            {
                Gamedate = statisticDto.Gamedate,
                CorrectAnswer = statisticDto.CorrectAnswer,
                Score = statisticDto.Score
            };

            var createdStatistic = await _repo.Create(statistics);
            return new StatisticDTO(createdStatistic);
        }

        public async Task<ServiceResponse<IEnumerable<StatisticDTO>>> GetAll()
        {
            List<Statistic> statistics = await _repo.GetAll();
            List<StatisticDTO> statisticsDto = statistics.Select(x => new StatisticDTO(x)).ToList();
            return new ServiceResponse<IEnumerable<StatisticDTO>>(statisticsDto)
            { Message = "Data query success", StatusCode = 2000 };
        }

        public async Task<StatisticDTO> GetById(int id)
        {
            var result = await _repo.GetById(x => x.Id == id);
            if (result is null)
                throw new Exception("Statistic not found");

            return new StatisticDTO(result);
        }
    }
}
