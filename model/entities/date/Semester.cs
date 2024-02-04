namespace API_for_mobile_app.model.entities.date
{
    public class Semester
    {
        public Guid ID { get; set; }
        public int? Year { get; set; }
        public bool? IsEven { get; set; }
        public virtual ICollection<Week> Weeks { get; set; }
    }
}