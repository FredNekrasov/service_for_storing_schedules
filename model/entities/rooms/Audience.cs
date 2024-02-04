using Microsoft.EntityFrameworkCore;

namespace API_for_mobile_app.model.entities.rooms
{
    [PrimaryKey(nameof(ID))]
    public class Audience
    {
        public Guid ID { get; set; }
        public Guid? AudienceTypeID { get; set; }
        public int? SeatsNumber { get; set; }
        public int? StudentNumber { get; set; }
        public string AudienceNumber { get; set; } = string.Empty;
        public virtual AudienceType AudienceType { get; set; }
        public virtual ICollection<Pair> Pairs { get; set; }
    }
}
