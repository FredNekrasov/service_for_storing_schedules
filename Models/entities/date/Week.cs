using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Web_API_for_scheduling.Models.entities.date
{
    public class Week
    {
        public Week()
        {
            Days = new HashSet<Day>();
        }
        [Key]
        public Guid WeekID { get; set; }
        [ForeignKey("Semester")]
        public Guid? SemesterID { get; set; }
        public int? WeekNumber { get; set; }
        public virtual ICollection<Day> Days { get; set; }
        public virtual Semester Semester { get; set; }
    }
}
