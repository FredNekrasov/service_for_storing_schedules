using Microsoft.EntityFrameworkCore;
using Web_API_for_scheduling.models;
using Web_API_for_scheduling.Models.entities;

namespace Web_API_for_scheduling.Models.repositories.implementation
{
    public class GroupsRepository(TimetableDbContext context) : IRepository<Group>
    {
        private readonly TimetableDbContext _context = context;
        public async Task<bool?> DeleteAsync(int id)
        {
            var squad = await _context.Group.FindAsync(id);
            if (squad == null) return false;
            if (await _context.Pair.FirstOrDefaultAsync(i => i.GroupID == id) != null) return null;
            _context.Group.Remove(squad);
            await _context.SaveChangesAsync();
            return true;
        }
        public bool EntityExists(int id) => _context.Group.Any(e => e.ID == id);
        public async Task<Group?> GetAsync(int id) => await _context.Group.FindAsync(id);
        public async Task<IEnumerable<Group>> GetListAsync() => await _context.Group.ToListAsync();
        public async Task<bool> PostData(Group entity)
        {
            _context.Group.Add(entity);
            await _context.SaveChangesAsync();
            return true;
        }
        public async Task<bool?> PutData(int id, Group entity)
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
