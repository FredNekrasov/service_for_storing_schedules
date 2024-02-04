using API_for_mobile_app.model;
using API_for_mobile_app.model.entities.date;

namespace Web_API_for_scheduling.Models.repositories.implementation.date
{
    public class DaysRepository(TimetableDbContext context) : IRepository<Day>
    {
        private readonly TimetableDbContext _context = context;
        public IEnumerable<Day> GetList() => _context.Day.ToList();
    }
}
