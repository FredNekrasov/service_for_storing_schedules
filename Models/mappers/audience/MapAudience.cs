using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Web_API_for_scheduling.models;
using Web_API_for_scheduling.Models.dto.rooms;
using Web_API_for_scheduling.Models.entities.rooms;

namespace Web_API_for_scheduling.Models.mappers.audience
{
    public class MapAudience(TimetableDbContext context, IMapper mapper) : IMapAudience
    {
        private readonly TimetableDbContext _context = context;
        private readonly IMapper _mapper = mapper;
        public async Task<Audience?> ToAudienceAsync(AudienceDto dto)
        {
            if (dto.AudienceType == null) return null;
            if (!await _context.AudienceType.AnyAsync(e => e.ID == dto.AudienceType.ID)) return null;
            return new Audience
            {
                ID = dto.ID,
                AudienceTypeID = dto.AudienceType.ID,
                SeatsNumber = dto.SeatsNumber,
                StudentNumber = dto.StudentNumber,
                AudienceNumber = dto.AudienceNumber
            };
        }

        public async Task<AudienceDto?> ToDtoAsync(Audience entity)
        {
            AudienceType? record = await _context.AudienceType.FindAsync(entity.AudienceTypeID);
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
