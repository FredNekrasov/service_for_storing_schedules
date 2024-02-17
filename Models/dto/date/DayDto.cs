namespace Web_API_for_scheduling.Models.dto.date
{
    public class DayDto
    {
        public int ID { get; set; }
        public string DayOfWeek { get; set; } = string.Empty;
        public int? Pair1 { get; set; }
        public int? Pair2 { get; set; }
        public int? Pair3 { get; set; }
        public int? Pair4 { get; set; }
        public int? Pair5 { get; set; }
        public int? Pair6 { get; set; }
        public int? Pair7 { get; set; }
        public WeekDto Week { get; set; }
    }
}
