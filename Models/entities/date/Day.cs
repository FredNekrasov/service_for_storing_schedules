using Microsoft.EntityFrameworkCore;

namespace Web_API_for_scheduling.Models.entities.date
{
    [PrimaryKey(nameof(ID))]
    public class Day
    {
        public Guid ID { get; set; }
        public string DayOfWeek { get; set; } = string.Empty;
        public Guid? WeekID { get; set; }
        public Guid? FirstPairID { get; set; }
        public Guid? SecondPairID { get; set; }
        public Guid? ThirdPairID { get; set; }
        public Guid? FourthPairID { get; set; }
        public Guid? FifthPairID { get; set; }
        public Guid? SixthPairID { get; set; }
        public Guid? SeventhPairID { get; set; }
        public virtual Pair Pair1 { get; set; }
        public virtual Pair Pair2 { get; set; }
        public virtual Pair Pair3 { get; set; }
        public virtual Pair Pair4 { get; set; }
        public virtual Pair Pair5 { get; set; }
        public virtual Pair Pair6 { get; set; }
        public virtual Pair Pair7 { get; set; }
        public virtual Week Week { get; set; }
    }
}
