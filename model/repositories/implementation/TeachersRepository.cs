using API_for_mobile_app.model;
using API_for_mobile_app.model.entities;

namespace Web_API_for_scheduling.Models.repositories.implementation
{
    public class TeachersRepository(TimetableDbContext context) : IRepository<Teacher>
    {
        private readonly TimetableDbContext _context = context;
        public IEnumerable<Teacher> GetList() => _context.Teacher.ToList();
    }
}
