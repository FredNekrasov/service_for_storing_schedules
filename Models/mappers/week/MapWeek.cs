using AutoMapper;
using Web_API_for_scheduling.models;
using Web_API_for_scheduling.Models.dto.date;
using Web_API_for_scheduling.Models.entities.date;

namespace Web_API_for_scheduling.Models.mappers.week
{
    public class MapWeek(TimetableDbContext context, IMapper mapper) : IMapSE<Week, WeekDto>
    {
        private readonly TimetableDbContext _context = context;
        private readonly IMapper _mapper = mapper;
        public async Task<WeekDto?> ToDtoAsync(Week entity)
        {
            Semester? record = await _context.Semester.FindAsync(entity.SemesterID);
            if (record == null) return null;
            return new WeekDto
            {
                ID = entity.ID,
                Semester = _mapper.Map<SemesterDto>(record),
                WeekNumber = entity.WeekNumber
            };
        }

        public Week? ToEntity(WeekDto dto)
        {
            if (dto.Semester == null) return null;
            if (!_context.Semester.Any(e => e.ID == dto.Semester.ID)) return null;

            return new Week
            {
                ID = dto.ID,
                SemesterID = dto.Semester.ID,
                WeekNumber = dto.WeekNumber
            };
        }
    }
}
