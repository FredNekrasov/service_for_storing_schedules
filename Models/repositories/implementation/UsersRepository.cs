using Microsoft.EntityFrameworkCore;
using Web_API_for_scheduling.models;
using Web_API_for_scheduling.Models.entities;

namespace Web_API_for_scheduling.Models.repositories.implementation
{
    public class UsersRepository(TimetableDbContext context) : IRepository<Users>
    {
        private readonly TimetableDbContext _context = context;
        public async Task<bool?> DeleteAsync(Guid id)
        {
            var users = await _context.Users.FindAsync(id);
            if (users == null) return false;

            _context.Users.Remove(users);
            await _context.SaveChangesAsync();
            return true;
        }
        public bool EntityExists(Guid id) => _context.Users.Any(e => e.UserID == id);
        public async Task<Users?> GetAsync(Guid id) => await _context.Users.FindAsync(id);
        public async Task<IEnumerable<Users>> GetListAsync() => await _context.Users.ToListAsync();
        public async Task<bool> PostData(Users entity)
        {
            _context.Users.Add(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool?> PutData(Guid id, Users entity)
        {
            if (id != entity.UserID) return false;
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
