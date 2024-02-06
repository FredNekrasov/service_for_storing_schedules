namespace Web_API_for_scheduling.Models.dto.rooms
{
    public class AudienceDto
    {
        public int ID { get; set; }
        public AudienceTypeDto AudienceType { get; set; }
        public int SeatsNumber { get; set; }
        public int StudentNumber { get; set; }
        public string AudienceNumber { get; set; } = string.Empty;
    }
}
