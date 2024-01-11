using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Web_API_for_scheduling.Models.entities.date;
using Web_API_for_scheduling.Models.entities.rooms;

namespace Web_API_for_scheduling.Models.entities
{
    public class Pair
    {
        public Pair()
        {
            Days = new HashSet<Day>();
            Days1 = new HashSet<Day>();
            Days2 = new HashSet<Day>();
            Days3 = new HashSet<Day>();
            Days4 = new HashSet<Day>();
            Days5 = new HashSet<Day>();
            Days6 = new HashSet<Day>();
        }
        [Key]
        public Guid PairID { get; set; }
        [ForeignKey("Audience")]
        public Guid? AudienceID { get; set; }
        [ForeignKey("Group")]
        public Guid? GroupID { get; set; }
        [ForeignKey("Subject")]
        public Guid? SubjectID { get; set; }
        [ForeignKey("Teacher")]
        public Guid? TeacherID { get; set; }
        public virtual ICollection<Day> Days { get; set; }
        public virtual ICollection<Day> Days1 { get; set; }
        public virtual ICollection<Day> Days2 { get; set; }
        public virtual ICollection<Day> Days3 { get; set; }
        public virtual ICollection<Day> Days4 { get; set; }
        public virtual ICollection<Day> Days5 { get; set; }
        public virtual ICollection<Day> Days6 { get; set; }
        public virtual Group Group { get; set; }
        public virtual Audience Audience { get; set; }
        public virtual Subject Subject { get; set; }
        public virtual Teacher Teacher { get; set; }
    }
}
