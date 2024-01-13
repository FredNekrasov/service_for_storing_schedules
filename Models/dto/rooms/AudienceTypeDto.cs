namespace Web_API_for_scheduling.Models.dto.rooms
{
    public class AudienceTypeDto
    {
        public Guid ID { get; set; }
        public string TypeName { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
    }
}
