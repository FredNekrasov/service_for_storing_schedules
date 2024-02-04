using API_for_mobile_app.model;
using API_for_mobile_app.model.entities.rooms;

namespace Web_API_for_scheduling.Models.repositories.implementation.room
{
    public class AudienceTypesRepository(TimetableDbContext context) : IRepository<AudienceType>
    {
        private readonly TimetableDbContext _context = context;
        public IEnumerable<AudienceType> GetList() => _context.AudienceType.ToList();
    }
}
