using Web_API_for_scheduling.Models.entities.date;
using Web_API_for_scheduling.Models.entities;

namespace Web_API_for_scheduling.Models.dto.date
{
    public class DayDto
    {
        public Guid ID { get; set; }
        public string DayOfWeek { get; set; } = string.Empty;
        public Pair? Pair1 { get; set; }
        public Pair? Pair2 { get; set; }
        public Pair? Pair3 { get; set; }
        public Pair? Pair4 { get; set; }
        public Pair? Pair5 { get; set; }
        public Pair? Pair6 { get; set; }
        public Pair? Pair7 { get; set; }
        public Week? Week { get; set; }
    }
}
