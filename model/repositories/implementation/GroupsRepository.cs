using API_for_mobile_app.model;
using API_for_mobile_app.model.entities;

namespace Web_API_for_scheduling.Models.repositories.implementation
{
    public class GroupsRepository(TimetableDbContext context) : IRepository<Group>
    {
        private readonly TimetableDbContext _context = context;
        public IEnumerable<Group> GetList() => _context.Group.ToList();
    }
}
