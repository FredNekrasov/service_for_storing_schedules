using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Web_API_for_scheduling.Models.entities.rooms
{
    public class Audience
    {
        public Audience()
        {
            Pairs = new HashSet<Pair>();
        }
        [Key]
        public Guid ID { get; set; }
        [ForeignKey("AudienceType")]
        public Guid? AudienceTypeID { get; set; }
        public int? SeatsNumber { get; set; }
        public int? StudentNumber { get; set; }
        public string AudienceNumber { get; set; } = string.Empty;
        public virtual AudienceType AudienceType { get; set; }
        public virtual ICollection<Pair> Pairs { get; set; }
    }
}
