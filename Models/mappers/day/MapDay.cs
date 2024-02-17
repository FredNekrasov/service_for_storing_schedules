using Web_API_for_scheduling.models;
using Web_API_for_scheduling.Models.dto.date;
using Web_API_for_scheduling.Models.entities;
using Web_API_for_scheduling.Models.entities.date;
using Web_API_for_scheduling.Models.mappers.pair;
using Web_API_for_scheduling.Models.mappers.week;

namespace Web_API_for_scheduling.Models.mappers.day
{
    public class MapDay(TimetableDbContext context, IMapWeek mapWeek) : IMapDay
    {
        private readonly TimetableDbContext _context = context;
        private readonly IMapWeek _mapWeek = mapWeek;
        public Day? ToDay(DayDto dto)
        {
            if (dto.Week == null) return null;

            if ((dto.Pair1 != null) && !_context.Pair.Any(e => e.PairID == dto.Pair1)) return null;
            if ((dto.Pair2 != null) && !_context.Pair.Any(e => e.PairID == dto.Pair2)) return null;
            if ((dto.Pair3 != null) && !_context.Pair.Any(e => e.PairID == dto.Pair3)) return null;
            if ((dto.Pair4 != null) && !_context.Pair.Any(e => e.PairID == dto.Pair4)) return null;
            if ((dto.Pair5 != null) && !_context.Pair.Any(e => e.PairID == dto.Pair5)) return null;
            if ((dto.Pair6 != null) && !_context.Pair.Any(e => e.PairID == dto.Pair6)) return null;
            if ((dto.Pair7 != null) && !_context.Pair.Any(e => e.PairID == dto.Pair7)) return null;
            if (!_context.Week.Any(e => e.ID == dto.Week.ID)) return null;

            return new Day { ID = dto.ID, FirstPairID = dto.Pair1, SecondPairID = dto.Pair2, ThirdPairID = dto.Pair3, FourthPairID = dto.Pair4, FifthPairID = dto.Pair5, SixthPairID = dto.Pair6, SeventhPairID = dto.Pair7, WeekID = dto.Week.ID, DayOfWeek = dto.DayOfWeek };
        }

        public async Task<DayDto?> ToDtoAsync(Day entity)
        {
            Week? week = await _context.Week.FindAsync(entity.WeekID);
            if (week == null) return null;
            Pair? pair1 = await _context.Pair.FindAsync(entity.FirstPairID);
            Pair? pair2 = await _context.Pair.FindAsync(entity.SecondPairID);
            Pair? pair3 = await _context.Pair.FindAsync(entity.ThirdPairID);
            Pair? pair4 = await _context.Pair.FindAsync(entity.FourthPairID);
            Pair? pair5 = await _context.Pair.FindAsync(entity.FifthPairID);
            Pair? pair6 = await _context.Pair.FindAsync(entity.SixthPairID);
            Pair? pair7 = await _context.Pair.FindAsync(entity.SeventhPairID);
            return new DayDto
            {
                ID = entity.ID,
                DayOfWeek = entity.DayOfWeek,
                Week = await _mapWeek.ToDtoAsync(week),
                Pair1 = pair1.PairID,
                Pair2 = pair2.PairID,
                Pair3 = pair3.PairID,
                Pair4 = pair4.PairID,
                Pair5 = pair5.PairID,
                Pair6 = pair6.PairID,
                Pair7 = pair7.PairID
            };
        }
    }
}
