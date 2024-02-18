using Microsoft.EntityFrameworkCore;
using Web_API_for_scheduling.models;
using Web_API_for_scheduling.Models.entities.rooms;

namespace Web_API_for_scheduling.Models.repositories.implementation.room
{
    public class AudienceTypesRepository(TimetableDbContext context) : IRepository<AudienceType>
    {
        private readonly TimetableDbContext _context = context;
        public async Task<bool?> DeleteAsync(int id)
        {
            var audienceType = await _context.AudienceType.FindAsync(id);
            if (audienceType == null) return false;
            if (await _context.Audience.FirstOrDefaultAsync(i => i.AudienceTypeID == id) != null) return null;
            _context.AudienceType.Remove(audienceType);
            await _context.SaveChangesAsync();
            return true;
        }
        public bool EntityExists(int id) => _context.AudienceType.Any(e => e.ID == id);
        public async Task<AudienceType?> GetAsync(int id) => await _context.AudienceType.FindAsync(id);
        public async Task<IEnumerable<AudienceType>> GetListAsync() => await _context.AudienceType.ToListAsync();
        public async Task<bool> PostData(AudienceType entity)
        {
            _context.AudienceType.Add(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool?> PutData(int id, AudienceType entity)
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
