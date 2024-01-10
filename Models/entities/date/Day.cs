using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Web_API_for_scheduling.Models.entities.date
{
    public class Day
    {
        [Key]
        public Guid DayID { get; set; }
        public string DayOfWeek { get; set; } = string.Empty;
        [ForeignKey("Week")]
        public Guid? WeekID { get; set; }
        [ForeignKey("Pair1")]
        public Guid? FirstPairID { get; set; }
        [ForeignKey("Pair2")]
        public Guid? SecondPairID { get; set; }
        [ForeignKey("Pair3")]
        public Guid? ThirdPairID { get; set; }
        [ForeignKey("Pair4")]
        public Guid? FourthPairID { get; set; }
        [ForeignKey("Pair5")]
        public Guid? FifthPairID { get; set; }
        [ForeignKey("Pair6")]
        public Guid? SixthPairID { get; set; }
        [ForeignKey("Pair7")]
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
