using Microsoft.EntityFrameworkCore;

namespace API_for_mobile_app.model.entities
{
    [PrimaryKey(nameof(ID))]
    public class Group
    {
        public Guid ID { get; set; }
        public string GroupNumber { get; set; } = string.Empty;
        public string ShortNumber { get; set; } = string.Empty;
        public int? StudentNumber { get; set; }
        public virtual ICollection<Pair> Pairs { get; set; }
    }
}
