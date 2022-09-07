﻿using _8Sual.DTO;
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

        public async Task<ServiceResponse<StatisticDTO>> Create(StatisticDTO statisticDto)
        {
            var result = await _repo.GetByFilter(x => x.Gamedate == statisticDto.Gamedate);
            var resultDto = new StatisticDTO(result);
            if (result is not null)
            {
                return new ServiceResponse<StatisticDTO>(resultDto)
                { Message = "There is such statistic in this game date in database", StatusCode = 4000 };
            }
            Statistic statistics = new Statistic()
            {
                Gamedate = statisticDto.Gamedate,
                CorrectAnswer = statisticDto.CorrectAnswer,
                Score = statisticDto.Score
            };

            var createdStatistic = await _repo.Create(statistics);
            var createdStatisticDto = new StatisticDTO(createdStatistic);
            return new ServiceResponse<StatisticDTO>(createdStatisticDto) 
            { Message = "Successfully created statistic",StatusCode = 2001};
        }

        public async Task<ServiceResponse<IEnumerable<StatisticDTO>>> GetAll()
        {
            List<Statistic> statistics = await _repo.GetAll();
            List<StatisticDTO> statisticsDto = statistics.Select(x => new StatisticDTO(x)).ToList();
            return new ServiceResponse<IEnumerable<StatisticDTO>>(statisticsDto)
            { Message = "Data query success", StatusCode = 2000 };
        }

        public async Task<ServiceResponse<StatisticDTO>> GetById(int id)
        {
            var result = await _repo.GetByFilter(x => x.Id == id);
            if (result is null)
            {
                return new ServiceResponse<StatisticDTO>(null)
                { Message = "Statistic with this id not found", StatusCode = 4000 };
            }

            var resultDto = new StatisticDTO(result);
            return new ServiceResponse<StatisticDTO>(resultDto) { Message = "Successfully operation",StatusCode = 2000};
        }
    }
}
