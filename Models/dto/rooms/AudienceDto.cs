using Web_API_for_scheduling.Models.entities.rooms;

namespace Web_API_for_scheduling.Models.dto.rooms
{
    public class AudienceDto
    {
        public Guid ID { get; set; }
        public AudienceType? AudienceType { get; set; }
        public int? SeatsNumber { get; set; }
        public int? StudentNumber { get; set; }
        public string AudienceNumber { get; set; } = string.Empty;
    }
}
