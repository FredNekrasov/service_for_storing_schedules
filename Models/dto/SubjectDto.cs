namespace Web_API_for_scheduling.Models.dto
{
    public class SubjectDto
    {
        public Guid ID { get; set; }
        public string SubjectName { get; set; } = string.Empty;
        public int? LectureHours { get; set; }
        public int? PracticHours { get; set; }
        public int? TotalHours { get; set; }
        public int? ConsultationHours { get; set; }
        public string TypeOfCertification { get; set; } = string.Empty;
    }
}
