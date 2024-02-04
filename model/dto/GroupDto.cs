namespace API_for_mobile_app.model.dto
{
    public class GroupDto
    {
        public Guid ID { get; set; }
        public string GroupNumber { get; set; } = string.Empty;
        public string ShortNumber { get; set; } = string.Empty;
        public int? StudentNumber { get; set; }
    }
}
