using API_for_mobile_app.model;
using API_for_mobile_app.model.entities.rooms;

namespace Web_API_for_scheduling.Models.repositories.implementation.room
{
    public class AudiencesRepository(TimetableDbContext context) : IRepository<Audience>
    {
        private readonly TimetableDbContext _context = context;
        public IEnumerable<Audience> GetList() => _context.Audience.ToList();
    }
}
