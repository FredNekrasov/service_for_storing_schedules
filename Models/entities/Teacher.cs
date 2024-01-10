using System.ComponentModel.DataAnnotations;

namespace Web_API_for_scheduling.Models.entities
{
    public class Teacher
    {
        [Key]
        public Guid TeacherID { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Surname { get; set; } = string.Empty;
        public string Patronymic { get; set; } = string.Empty;
        public Teacher()
        {
            Pairs = new HashSet<Pair>();
        }
        public virtual ICollection<Pair> Pairs { get; set; }
    }
}
