using Web_API_for_scheduling.Models.entities.date;
using Web_API_for_scheduling.Models.entities;

namespace Web_API_for_scheduling.Models.dto.date
{
    public class DayDto
    {
        public Guid ID { get; set; }
        public string DayOfWeek { get; set; } = string.Empty;
        public PairDto? Pair1 { get; set; }
        public PairDto? Pair2 { get; set; }
        public PairDto? Pair3 { get; set; }
        public PairDto? Pair4 { get; set; }
        public PairDto? Pair5 { get; set; }
        public PairDto? Pair6 { get; set; }
        public PairDto? Pair7 { get; set; }
        public WeekDto? Week { get; set; }
    }
}
