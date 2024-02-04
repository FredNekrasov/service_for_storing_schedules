using API_for_mobile_app.model;
using API_for_mobile_app.model.entities.date;

namespace Web_API_for_scheduling.Models.repositories.implementation.date
{
    public class WeeksRepository(TimetableDbContext context) : IRepository<Week>
    {
        private readonly TimetableDbContext _context = context;
        public IEnumerable<Week> GetList() => _context.Week.ToList();
    }
}
