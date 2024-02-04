using API_for_mobile_app.model;
using API_for_mobile_app.model.entities;

namespace Web_API_for_scheduling.Models.repositories.implementation
{
    public class SubjectsRepository(TimetableDbContext context) : IRepository<Subject>
    {
        private readonly TimetableDbContext _context = context;
        public IEnumerable<Subject> GetList() => _context.Subject.ToList();
    }
}
