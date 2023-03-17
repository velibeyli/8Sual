using _8Sual.DTO;
using _8Sual.Wrappers;

namespace _8Sual.Services.Interfaces
{
    public interface IStatisticService
    {
        Task<ServiceResponse<IEnumerable<StatisticDTO>>> GetAll();
        Task<ServiceResponse<StatisticDTO>> GetById(int id);
        Task<ServiceResponse<StatisticDTO>> Create(StatisticDTO statisticDto);
    }
}
