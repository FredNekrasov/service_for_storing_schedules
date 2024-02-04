using API_for_mobile_app.model.dto.rooms;

namespace API_for_mobile_app.model.dto
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
