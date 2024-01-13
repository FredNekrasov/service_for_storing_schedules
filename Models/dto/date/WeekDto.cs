using Web_API_for_scheduling.Models.entities.date;

namespace Web_API_for_scheduling.Models.dto.date
{
    public class WeekDto
    {
        public Guid ID { get; set; }
        public Semester? Semester { get; set; }
        public int? WeekNumber { get; set; }
    }
}
