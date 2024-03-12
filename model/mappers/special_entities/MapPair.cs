using API_for_mobile_app.model.dto;
using API_for_mobile_app.model.dto.rooms;
using API_for_mobile_app.model.entities;
using API_for_mobile_app.model.entities.rooms;
using AutoMapper;

namespace API_for_mobile_app.model.mappers.special_entities
{
    public class MapPair(
        TimetableDbContext context,
        IMapper mapper,
        IMapSpecialEntities<AudienceDto, Audience> mapAudience) : IMapSpecialEntities<PairDto, Pair>
    {
        private readonly TimetableDbContext _context = context;
        private readonly IMapper _mapper = mapper;
        private readonly IMapSpecialEntities<AudienceDto, Audience> _mapAudience = mapAudience;
        public PairDto? ToDTO(Pair? entity)
        {
            if (entity == null) return null;
            Audience? audience = _context.Audience.Find(entity.AudienceID);
            if (audience == null) return null;
            Group? group = _context.Group.Find(entity.GroupID);
            if (group == null) return null;
            Subject? subject = _context.Subject.Find(entity.SubjectID);
            if (subject == null) return null;
            Teacher? teacher = _context.Teacher.Find(entity.TeacherID);
            if (teacher == null) return null;
            return new PairDto
            {
                PairID = entity.PairID,
                Audience = _mapAudience.ToDTO(audience),
                Group = _mapper.Map<GroupDto>(group),
                Subject = _mapper.Map<SubjectDto>(subject),
                Teacher = _mapper.Map<TeacherDto>(teacher)
            };
        }
    }
}
