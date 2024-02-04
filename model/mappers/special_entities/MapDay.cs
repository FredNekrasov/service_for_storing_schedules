using API_for_mobile_app.model.dto;
using API_for_mobile_app.model.dto.date;
using API_for_mobile_app.model.entities;
using API_for_mobile_app.model.entities.date;

namespace API_for_mobile_app.model.mappers.special_entities
{
    public class MapDay(
        TimetableDbContext context,
        IMapSpecialEntities<PairDto, Pair> mapper,
        IMapSpecialEntities<WeekDto, Week> mapWeek) : IMapSpecialEntities<DayDto, Day>
    {
        private readonly TimetableDbContext _context = context;
        private readonly IMapSpecialEntities<PairDto, Pair> _mapper = mapper;
        private readonly IMapSpecialEntities<WeekDto, Week> _mapWeek = mapWeek;
        public DayDto? ToDTO(Day entity)
        {
            Week? week = _context.Week.Find(entity.WeekID);
            if (week == null) return null;
            Pair? pair1 = _context.Pair.Find(entity.FirstPairID);
            if (pair1 == null) return null;
            Pair? pair2 = _context.Pair.Find(entity.SecondPairID);
            if (pair2 == null) return null;
            Pair? pair3 = _context.Pair.Find(entity.ThirdPairID);
            if (pair3 == null) return null;
            Pair? pair4 = _context.Pair.Find(entity.FourthPairID);
            if (pair4 == null) return null;
            Pair? pair5 = _context.Pair.Find(entity.FifthPairID);
            if (pair5 == null) return null;
            Pair? pair6 = _context.Pair.Find(entity.SixthPairID);
            if (pair6 == null) return null;
            Pair? pair7 = _context.Pair.Find(entity.SeventhPairID);
            if (pair7 == null) return null;
            return new DayDto
            {
                ID = entity.ID,
                DayOfWeek = entity.DayOfWeek,
                Week = _mapWeek.ToDTO(week),
                Pair1 = _mapper.ToDTO(pair1),
                Pair2 = _mapper.ToDTO(pair2),
                Pair3 = _mapper.ToDTO(pair3),
                Pair4 = _mapper.ToDTO(pair4),
                Pair5 = _mapper.ToDTO(pair5),
                Pair6 = _mapper.ToDTO(pair6),
                Pair7 = _mapper.ToDTO(pair7)
            };
        }
    }
}
