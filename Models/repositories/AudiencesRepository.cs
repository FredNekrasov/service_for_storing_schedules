using Microsoft.EntityFrameworkCore;
using Web_API_for_scheduling.models;
using Web_API_for_scheduling.Models.entities.rooms;

namespace Web_API_for_scheduling.Models.repositories
{
    public class AudiencesRepository(TimetableDbContext context) : IRepository<Audience>
    {
        private readonly TimetableDbContext _context = context;
        public async Task<bool> DeleteAsync(Guid id)
        {
            var audience = await _context.Audience.FindAsync(id);
            if (audience == null) return false;
            _context.Audience.Remove(audience);
            await _context.SaveChangesAsync();
            return true;
        }
        public bool EntityExists(Guid id) => _context.Audience.Any(e => e.ID == id);
        public async Task<Audience?> GetAsync(Guid id) => await _context.Audience.FindAsync(id);
        public async Task<IEnumerable<Audience>> GetListAsync() => await _context.Audience.ToListAsync();
        public async Task<bool> PostData(Audience entity)
        {
            _context.Audience.Add(entity);
            await _context.SaveChangesAsync();
            return true;
        }
        public async Task<bool?> PutData(Guid id, Audience entity)
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
