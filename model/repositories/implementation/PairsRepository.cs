using API_for_mobile_app.model;
using API_for_mobile_app.model.entities;

namespace Web_API_for_scheduling.Models.repositories.implementation
{
    public class PairsRepository(TimetableDbContext context) : IRepository<Pair>
    {
        private readonly TimetableDbContext _context = context;
        public IEnumerable<Pair> GetList() => _context.Pair.ToList();
    }
}
