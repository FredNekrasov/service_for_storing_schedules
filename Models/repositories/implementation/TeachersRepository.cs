using Microsoft.EntityFrameworkCore;
using Web_API_for_scheduling.models;
using Web_API_for_scheduling.Models.entities;

namespace Web_API_for_scheduling.Models.repositories.implementation
{
    public class TeachersRepository(TimetableDbContext context) : IRepository<Teacher>
    {
        private readonly TimetableDbContext _context = context;
        public async Task<bool?> DeleteAsync(int id)
        {
            var teacher = await _context.Teacher.FindAsync(id);
            if (teacher == null) return false;

            if (await _context.Pair.FirstOrDefaultAsync(i => i.TeacherID == id) != null) return null;
            _context.Teacher.Remove(teacher);
            await _context.SaveChangesAsync();
            return true;
        }
        public bool EntityExists(int id) => _context.Teacher.Any(e => e.ID == id);
        public async Task<Teacher?> GetAsync(int id) => await _context.Teacher.FindAsync(id);
        public async Task<IEnumerable<Teacher>> GetListAsync() => await _context.Teacher.ToListAsync();
        public async Task<bool> PostData(Teacher entity)
        {
            _context.Teacher.Add(entity);
            await _context.SaveChangesAsync();
            return true;
        }
        public async Task<bool?> PutData(int id, Teacher entity)
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
