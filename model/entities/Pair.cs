using API_for_mobile_app.model.entities.date;
using API_for_mobile_app.model.entities.rooms;
using Microsoft.EntityFrameworkCore;

namespace API_for_mobile_app.model.entities
{
    [PrimaryKey(nameof(PairID))]
    public class Pair
    {
        public Guid PairID { get; set; }
        public Guid? AudienceID { get; set; }
        public Guid? GroupID { get; set; }
        public Guid? SubjectID { get; set; }
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
