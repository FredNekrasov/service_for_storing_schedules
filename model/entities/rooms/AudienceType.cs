using Microsoft.EntityFrameworkCore;

namespace API_for_mobile_app.model.entities.rooms
{
    [PrimaryKey(nameof(ID))]
    public class AudienceType
    {
        public Guid ID { get; set; }
        public string TypeName { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public virtual ICollection<Audience> Rooms { get; set; }
    }
}
