using API_for_mobile_app.model.dto.rooms;
using API_for_mobile_app.model.entities.rooms;
using AutoMapper;

namespace API_for_mobile_app.model.mappers.special_entities
{
    public class MapAudience(TimetableDbContext context, IMapper mapper) : IMapSpecialEntities<AudienceDto, Audience>
    {
        private readonly TimetableDbContext _context = context;
        private readonly IMapper _mapper = mapper;
        public AudienceDto? ToDTO(Audience entity)
        {
            AudienceType? record = _context.AudienceType.Find(entity.AudienceTypeID);
            if (record == null) return null;
            return new AudienceDto
            {
                ID = entity.ID,
                AudienceType = _mapper.Map<AudienceTypeDto>(record),
                SeatsNumber = entity.SeatsNumber,
                StudentNumber = entity.StudentNumber,
                AudienceNumber = entity.AudienceNumber
            };
        }
    }
}
