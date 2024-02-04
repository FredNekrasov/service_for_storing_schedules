namespace API_for_mobile_app.model.entities.date
{
    public class Week
    {
        public Guid ID { get; set; }
        public Guid? SemesterID { get; set; }
        public int? WeekNumber { get; set; }
        public virtual ICollection<Day> Days { get; set; }
        public virtual Semester Semester { get; set; }
    }
}
