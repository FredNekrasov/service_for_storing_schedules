using AutoMapper;
using Web_API_for_scheduling.models;
using Web_API_for_scheduling.Models.dto;
using Web_API_for_scheduling.Models.dto.rooms;
using Web_API_for_scheduling.Models.entities;
using Web_API_for_scheduling.Models.entities.rooms;
using Web_API_for_scheduling.Models.mappers.audience;

namespace Web_API_for_scheduling.Models.mappers.pair
{
    public class MapPair(TimetableDbContext context, IMapper mapper, IMapAudience mapAudience) : IMapPair
    {
        private readonly TimetableDbContext _context = context;
        private readonly IMapper _mapper = mapper;
        private readonly IMapAudience _mapAudience = mapAudience;
        public async Task<PairDto?> ToDtoAsync(Pair entity)
        {
            Audience? audience = await _context.Audience.FindAsync(entity.AudienceID);
            if (audience == null) return null;
            Group? group = await _context.Group.FindAsync(entity.GroupID);
            if (group == null) return null;
            Subject? subject = await _context.Subject.FindAsync(entity.SubjectID);
            if (subject == null) return null;
            Teacher? teacher = await _context.Teacher.FindAsync(entity.TeacherID);
            if (teacher == null) return null;
            return new PairDto
            {
                PairID = entity.PairID,
                Audience = await _mapAudience.ToDtoAsync(audience),
                Group = _mapper.Map<GroupDto>(group),
                Subject = _mapper.Map<SubjectDto>(subject),
                Teacher = _mapper.Map<TeacherDto>(teacher)
            };
        }

        public Pair? ToPair(PairDto dto)
        {
            if (dto.Group == null) return null;
            if (dto.Teacher == null) return null;
            if (dto.Subject == null) return null;
            if (dto.Audience == null) return null;
            if (!_context.Group.Any(e => e.ID == dto.Group.ID)) return null;
            if (!_context.Teacher.Any(e => e.ID == dto.Teacher.ID)) return null;
            if (!_context.Subject.Any(e => e.ID == dto.Subject.ID)) return null;
            if (!_context.Audience.Any(e => e.ID == dto.Audience.ID)) return null;

            return new Pair
            {
                PairID = dto.PairID,
                GroupID = dto.Group.ID,
                TeacherID = dto.Teacher.ID,
                SubjectID = dto.Subject.ID,
                AudienceID = dto.Audience.ID
            };
        }
    }
}
