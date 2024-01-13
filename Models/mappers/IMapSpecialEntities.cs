using Web_API_for_scheduling.Models.dto;
using Web_API_for_scheduling.Models.dto.date;
using Web_API_for_scheduling.Models.dto.rooms;
using Web_API_for_scheduling.Models.entities;
using Web_API_for_scheduling.Models.entities.date;
using Web_API_for_scheduling.Models.entities.rooms;

namespace Web_API_for_scheduling.Models.mappers
{
    public interface IMapSpecialEntities
    {
        Audience? ToAudience(AudienceDto dto);
        Week? ToWeek(WeekDto dto);
        Pair? ToPair(PairDto dto);
        Day? ToDay(DayDto dto);
    }
}
