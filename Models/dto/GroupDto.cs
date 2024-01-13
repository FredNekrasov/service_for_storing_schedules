namespace Web_API_for_scheduling.Models.dto
{
    public class GroupDto
    {
        public Guid ID { get; set; }
        public string GroupNumber { get; set; } = string.Empty;
        public string ShortNumber { get; set; } = string.Empty;
        public int? StudentNumber { get; set; }
    }
}
