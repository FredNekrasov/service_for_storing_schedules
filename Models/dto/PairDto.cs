using Web_API_for_scheduling.Models.entities.rooms;
using Web_API_for_scheduling.Models.entities;

namespace Web_API_for_scheduling.Models.dto
{
    public class PairDto
    {
        public Guid PairID { get; set; }
        public Group? Group { get; set; }
        public Audience? Audience { get; set; }
        public Subject? Subject { get; set; }
        public Teacher? Teacher { get; set; }
    }
}
