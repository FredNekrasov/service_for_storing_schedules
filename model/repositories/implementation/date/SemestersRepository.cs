using API_for_mobile_app.model;
using API_for_mobile_app.model.entities.date;

namespace Web_API_for_scheduling.Models.repositories.implementation.date;
public class SemestersRepository(TimetableDbContext context) : IRepository<Semester>
{
    private readonly TimetableDbContext _context = context;
    public IEnumerable<Semester> GetList() => _context.Semester.ToList();
}
