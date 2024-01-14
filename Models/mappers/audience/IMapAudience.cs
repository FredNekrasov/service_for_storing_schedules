using Web_API_for_scheduling.Models.dto.rooms;
using Web_API_for_scheduling.Models.entities.rooms;

namespace Web_API_for_scheduling.Models.mappers.audience
{
    public interface IMapAudience
    {
        Task<Audience?> ToAudienceAsync(AudienceDto dto);
        Task<AudienceDto?> ToDtoAsync(Audience entity);
    }
}
