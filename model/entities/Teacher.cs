using Microsoft.EntityFrameworkCore;

namespace API_for_mobile_app.model.entities
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
