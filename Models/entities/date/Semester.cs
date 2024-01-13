namespace Web_API_for_scheduling.Models.entities.date
{
    public class Semester
    {
        public Guid ID { get; set; }
        public int? Year { get; set; }
        public bool? IsEven { get; set; }
        public virtual ICollection<Week> Weeks { get; set; }
    }
}