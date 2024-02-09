using Microsoft.EntityFrameworkCore;

namespace API_for_mobile_app.model.entities.date
{
    [PrimaryKey(nameof(ID))]
    public class Day
    {
        public int ID { get; set; }
        public string DayOfWeek { get; set; } = string.Empty;
        public int WeekID { get; set; }
        public int? FirstPairID { get; set; }
        public int? SecondPairID { get; set; }
        public int? ThirdPairID { get; set; }
        public int? FourthPairID { get; set; }
        public int? FifthPairID { get; set; }
        public int? SixthPairID { get; set; }
        public int? SeventhPairID { get; set; }
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
