using Microsoft.EntityFrameworkCore;

namespace Web_API_for_scheduling.Models.entities
{
    [PrimaryKey(nameof(ID))]
    public class Teacher
    {
        public int ID { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Surname { get; set; } = string.Empty;
        public string Patronymic { get; set; } = string.Empty;
        public virtual ICollection<Pair> Pairs { get; set; }
    }
}
