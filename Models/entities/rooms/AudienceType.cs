using System.ComponentModel.DataAnnotations;

namespace Web_API_for_scheduling.Models.entities.rooms
{
    public class AudienceType
    {
        public AudienceType()
        {
            Rooms = new HashSet<Audience>();
        }
        [Key]
        public Guid TypeID { get; set; }
        public string TypeName { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public virtual ICollection<Audience> Rooms { get; set; }
    }
}
