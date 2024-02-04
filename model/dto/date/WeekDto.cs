namespace API_for_mobile_app.model.dto.date
{
    public class WeekDto
    {
        public Guid ID { get; set; }
        public SemesterDto? Semester { get; set; }
        public int? WeekNumber { get; set; }
    }
}
