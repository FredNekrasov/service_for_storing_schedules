using API_for_mobile_app.model.dto.date;
using API_for_mobile_app.model.entities.date;
using AutoMapper;

namespace API_for_mobile_app.model.mappers.special_entities
{
    public class MapWeek(TimetableDbContext context, IMapper mapper) : IMapSpecialEntities<WeekDto, Week>
    {
        private readonly TimetableDbContext _context = context;
        private readonly IMapper _mapper = mapper;
        public WeekDto? ToDTO(Week entity)
        {
            Semester? record = _context.Semester.Find(entity.SemesterID);
            if (record == null) return null;
            return new WeekDto
            {
                ID = entity.ID,
                Semester = _mapper.Map<SemesterDto>(record),
                WeekNumber = entity.WeekNumber
            };
        }
    }
}
