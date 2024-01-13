using Microsoft.EntityFrameworkCore;
using Web_API_for_scheduling.models;
using Web_API_for_scheduling.Models.entities;

namespace Web_API_for_scheduling.Models.repositories
{
    public class SubjectsRepository(TimetableDbContext context) : IRepository<Subject>
    {
        private readonly TimetableDbContext _context = context;
        public async Task<bool> DeleteAsync(Guid id)
        {
            var subject = await _context.Subject.FindAsync(id);
            if (subject == null) return false;

            _context.Subject.Remove(subject);
            await _context.SaveChangesAsync();
            return true;
        }
        public bool EntityExists(Guid id) => _context.Subject.Any(e => e.ID == id);
        public async Task<Subject?> GetAsync(Guid id) => await _context.Subject.FindAsync(id);
        public async Task<IEnumerable<Subject>> GetListAsync() => await _context.Subject.ToListAsync();
        public async Task<bool> PostData(Subject entity)
        {
            _context.Subject.Add(entity);
            await _context.SaveChangesAsync();
            return true;
        }
        public async Task<bool?> PutData(Guid id, Subject entity)
        {
            if (id != entity.ID) return false;

            _context.Entry(entity).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EntityExists(id)) return null; else return false;
            }
            return true;
        }
    }
}
