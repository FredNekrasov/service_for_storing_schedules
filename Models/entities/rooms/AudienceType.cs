using Microsoft.EntityFrameworkCore;

namespace Web_API_for_scheduling.Models.entities.rooms
{
    [PrimaryKey(nameof(ID))]
    public class AudienceType
    {
        public int ID { get; set; }
        public string TypeName { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public virtual ICollection<Audience> Rooms { get; set; }
    }
}
