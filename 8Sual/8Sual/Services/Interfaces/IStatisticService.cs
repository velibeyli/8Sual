using _8Sual.DTO;
using _8Sual.Wrappers;

namespace _8Sual.Services.Interfaces
{
    public interface IStatisticService
    {
        Task<ServiceResponse<IEnumerable<StatisticDTO>>> GetAll();
        Task<StatisticDTO> GetById(int id);
        Task<StatisticDTO> Create(StatisticDTO statisticDto);
    }
}
