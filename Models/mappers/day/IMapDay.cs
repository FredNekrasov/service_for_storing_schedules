using Web_API_for_scheduling.Models.dto.date;
using Web_API_for_scheduling.Models.entities.date;

namespace Web_API_for_scheduling.Models.mappers.day
{
    public interface IMapDay
    {
        Day? ToDay(DayDto dto);
        Task<DayDto?> ToDtoAsync(Day entity);
    }
}
