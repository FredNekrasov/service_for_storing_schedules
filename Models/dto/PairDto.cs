using Web_API_for_scheduling.Models.dto.rooms;

namespace Web_API_for_scheduling.Models.dto
{
    public class PairDto
    {
        public Guid PairID { get; set; }
        public GroupDto? Group { get; set; }
        public AudienceDto? Audience { get; set; }
        public SubjectDto? Subject { get; set; }
        public TeacherDto? Teacher { get; set; }
    }
}
