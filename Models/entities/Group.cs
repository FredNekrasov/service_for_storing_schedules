using System.ComponentModel.DataAnnotations;

namespace Web_API_for_scheduling.Models.entities
{
    public class Group
    {
        public Group()
        {
            Pairs = new HashSet<Pair>();
        }
        [Key]
        public Guid ID { get; set; }
        public string GroupNumber { get; set; } = string.Empty;
        public string ShortNumber { get; set; } = string.Empty;
        public int? StudentNumber { get; set; }
        public virtual ICollection<Pair> Pairs { get; set; }
    }
}
