using Web_API_for_scheduling.models;
using Web_API_for_scheduling.Models.dto;
using Web_API_for_scheduling.Models.dto.date;
using Web_API_for_scheduling.Models.dto.rooms;
using Web_API_for_scheduling.Models.entities;
using Web_API_for_scheduling.Models.entities.date;
using Web_API_for_scheduling.Models.entities.rooms;

namespace Web_API_for_scheduling.Models.mappers
{
    public class MapSpecialEntities(TimetableDbContext context) : IMapSpecialEntities
    {
        private readonly TimetableDbContext _context = context;
        public Audience? ToAudience(AudienceDto dto)
        {
            if (dto.AudienceType == null) return null;

            return new Audience
            {
                ID = dto.ID,
                I
            };
        }

        public Day? ToDay(DayDto dto)
        {
            throw new NotImplementedException();
        }

        public Pair? ToPair(PairDto dto)
        {
            throw new NotImplementedException();
        }

        public Week? ToWeek(WeekDto dto)
        {
            throw new NotImplementedException();
        }
    }
}
