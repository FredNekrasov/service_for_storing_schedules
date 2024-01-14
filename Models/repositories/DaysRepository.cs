using Microsoft.EntityFrameworkCore;
using Web_API_for_scheduling.models;
using Web_API_for_scheduling.Models.entities.date;

namespace Web_API_for_scheduling.Models.repositories
{
    public class DaysRepository(TimetableDbContext context) : IRepository<Day>
    {
        private readonly TimetableDbContext _context = context;
        public async Task<bool?> DeleteAsync(Guid id)
        {
            var day = await _context.Day.FindAsync(id);
            if (day == null) return false;
            _context.Day.Remove(day);
            await _context.SaveChangesAsync();
            return true;
        }
        public bool EntityExists(Guid id) => _context.Day.Any(e => e.ID == id);
        public async Task<Day?> GetAsync(Guid id) => await _context.Day.FindAsync(id);
        public async Task<IEnumerable<Day>> GetListAsync() => await _context.Day.ToListAsync();
        public async Task<bool> PostData(Day entity)
        {
            _context.Day.Add(entity);
            await _context.SaveChangesAsync();
            return true;
        }
        public async Task<bool?> PutData(Guid id, Day entity)
        {
            if (id != entity.ID) return false;
            _context.Entry(entity).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EntityExists(id)) return false; else return false;
            }
            return true;
        }
    }
}
