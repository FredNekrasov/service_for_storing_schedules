using Web_API_for_scheduling.Models.dto.date;
using Web_API_for_scheduling.Models.entities.date;

namespace Web_API_for_scheduling.Models.mappers.week
{
    public interface IMapWeek
    {
        Week? ToWeek(WeekDto dto);
        Task<WeekDto?> ToDtoAsync(Week entity);
    }
}
