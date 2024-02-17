using Web_API_for_scheduling.models;
using Web_API_for_scheduling.Models.dto.date;
using Web_API_for_scheduling.Models.entities;
using Web_API_for_scheduling.Models.entities.date;

namespace Web_API_for_scheduling.Models.mappers.specialEntities
{
    public class MapDay(TimetableDbContext context, IMapSE<Week, WeekDto> mapWeek) : IMapSE<Day, DayDto>
    {
        private readonly TimetableDbContext _context = context;
        private readonly IMapSE<Week, WeekDto> _mapWeek = mapWeek;
        public Day? ToEntity(DayDto dto)
        {
            if (dto.Week == null) return null;

            if (dto.Pair1 != null && !_context.Pair.Any(e => e.PairID == dto.Pair1)) return null;
            if (dto.Pair2 != null && !_context.Pair.Any(e => e.PairID == dto.Pair2)) return null;
            if (dto.Pair3 != null && !_context.Pair.Any(e => e.PairID == dto.Pair3)) return null;
            if (dto.Pair4 != null && !_context.Pair.Any(e => e.PairID == dto.Pair4)) return null;
            if (dto.Pair5 != null && !_context.Pair.Any(e => e.PairID == dto.Pair5)) return null;
            if (dto.Pair6 != null && !_context.Pair.Any(e => e.PairID == dto.Pair6)) return null;
            if (dto.Pair7 != null && !_context.Pair.Any(e => e.PairID == dto.Pair7)) return null;
            if (!_context.Week.Any(e => e.ID == dto.Week.ID)) return null;

            return new Day { ID = dto.ID, FirstPairID = dto.Pair1, SecondPairID = dto.Pair2, ThirdPairID = dto.Pair3, FourthPairID = dto.Pair4, FifthPairID = dto.Pair5, SixthPairID = dto.Pair6, SeventhPairID = dto.Pair7, WeekID = dto.Week.ID, DayOfWeek = dto.DayOfWeek };
        }

        public async Task<DayDto?> ToDtoAsync(Day entity)
        {
            int? p1 = entity.FirstPairID;
            int? p2 = entity.SecondPairID;
            int? p3 = entity.ThirdPairID;
            int? p4 = entity.FourthPairID;
            int? p5 = entity.FifthPairID;
            int? p6 = entity.SixthPairID;
            int? p7 = entity.SeventhPairID;
            Week? week = await _context.Week.FindAsync(entity.WeekID);
            if (week == null) return null;
            return new DayDto
            {
                ID = entity.ID,
                DayOfWeek = entity.DayOfWeek,
                Week = await _mapWeek.ToDtoAsync(week),
                Pair1 = p1,
                Pair2 = p2,
                Pair3 = p3,
                Pair4 = p4,
                Pair5 = p5,
                Pair6 = p6,
                Pair7 = p7
            };
        }
    }
}
