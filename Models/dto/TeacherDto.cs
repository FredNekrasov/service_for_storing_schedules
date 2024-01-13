namespace Web_API_for_scheduling.Models.dto
{
    public class TeacherDto
    {
        public Guid ID { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Surname { get; set; } = string.Empty;
        public string Patronymic { get; set; } = string.Empty;
    }
}
