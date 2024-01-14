using Web_API_for_scheduling.models;
using Web_API_for_scheduling.Models.dto;
using Web_API_for_scheduling.Models.dto.date;
using Web_API_for_scheduling.Models.entities;
using Web_API_for_scheduling.Models.entities.date;
using Web_API_for_scheduling.Models.mappers.pair;
using Web_API_for_scheduling.Models.mappers.week;

namespace Web_API_for_scheduling.Models.mappers.day
{
    public class MapDay(TimetableDbContext context, IMapPair mapper, IMapWeek mapWeek) : IMapDay
    {
        private readonly TimetableDbContext _context = context;
        private readonly IMapPair _mapper = mapper;
        private readonly IMapWeek _mapWeek = mapWeek;
        public Day? ToDay(DayDto dto)
        {
            if (dto.Pair1 == null) return null;
            if (dto.Pair2 == null) return null;
            if (dto.Pair3 == null) return null;
            if (dto.Pair4 == null) return null;
            if (dto.Pair5 == null) return null;
            if (dto.Pair6 == null) return null;
            if (dto.Pair7 == null) return null;
            if (dto.Week == null) return null;

            if (!_context.Pair.Any(e => e.PairID == dto.Pair1.PairID)) return null;
            if (!_context.Pair.Any(e => e.PairID == dto.Pair2.PairID)) return null;
            if (!_context.Pair.Any(e => e.PairID == dto.Pair3.PairID)) return null;
            if (!_context.Pair.Any(e => e.PairID == dto.Pair4.PairID)) return null;
            if (!_context.Pair.Any(e => e.PairID == dto.Pair5.PairID)) return null;
            if (!_context.Pair.Any(e => e.PairID == dto.Pair6.PairID)) return null;
            if (!_context.Pair.Any(e => e.PairID == dto.Pair7.PairID)) return null;
            if (!_context.Week.Any(e => e.ID == dto.Week.ID)) return null;

            return new Day { ID = dto.ID, FirstPairID = dto.Pair1.PairID, SecondPairID = dto.Pair2.PairID, ThirdPairID = dto.Pair3.PairID, FourthPairID = dto.Pair4.PairID, FifthPairID = dto.Pair5.PairID, SixthPairID = dto.Pair6.PairID, SeventhPairID = dto.Pair7.PairID, WeekID = dto.Week.ID, DayOfWeek = dto.DayOfWeek };
        }

        public async Task<DayDto?> ToDtoAsync(Day entity)
        {
            Week? week = await _context.Week.FindAsync(entity.WeekID);
            if (week == null) return null;
            Pair? pair1 = await _context.Pair.FindAsync(entity.FirstPairID);
            if (pair1 == null) return null;
            Pair? pair2 = await _context.Pair.FindAsync(entity.SecondPairID);
            if (pair2 == null) return null;
            Pair? pair3 = await _context.Pair.FindAsync(entity.ThirdPairID);
            if (pair3 == null) return null;
            Pair? pair4 = await _context.Pair.FindAsync(entity.FourthPairID);
            if (pair4 == null) return null;
            Pair? pair5 = await _context.Pair.FindAsync(entity.FifthPairID);
            if (pair5 == null) return null;
            Pair? pair6 = await _context.Pair.FindAsync(entity.SixthPairID);
            if (pair6 == null) return null;
            Pair? pair7 = await _context.Pair.FindAsync(entity.SeventhPairID);
            if (pair7 == null) return null;
            return new DayDto { ID = entity.ID, DayOfWeek = entity.DayOfWeek, Week = await _mapWeek.ToDtoAsync(week), Pair1 = await _mapper.ToDtoAsync(pair1), Pair2 = await _mapper.ToDtoAsync(pair2), Pair3 = await _mapper.ToDtoAsync(pair3), Pair4 = await _mapper.ToDtoAsync(pair4), Pair5 = await _mapper.ToDtoAsync(pair5), Pair6 = await _mapper.ToDtoAsync(pair6), Pair7 = await _mapper.ToDtoAsync(pair7) };
        }
    }
}
