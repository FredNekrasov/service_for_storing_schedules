using Microsoft.EntityFrameworkCore;
using Web_API_for_scheduling.models;
using Web_API_for_scheduling.Models.entities;

namespace Web_API_for_scheduling.Models.repositories.implementation
{
    public class PairsRepository(TimetableDbContext context) : IRepository<Pair>
    {
        private readonly TimetableDbContext _context = context;
        public async Task<bool?> DeleteAsync(int id)
        {
            var pair = await _context.Pair.FindAsync(id);
            if (pair == null) return false;
            if (await _context.Day.FirstOrDefaultAsync(i => i.FirstPairID == id) != null) return null;
            if (await _context.Day.FirstOrDefaultAsync(i => i.SecondPairID == id) != null) return null;
            if (await _context.Day.FirstOrDefaultAsync(i => i.ThirdPairID == id) != null) return null;
            if (await _context.Day.FirstOrDefaultAsync(i => i.FourthPairID == id) != null) return null;
            if (await _context.Day.FirstOrDefaultAsync(i => i.FifthPairID == id) != null) return null;
            if (await _context.Day.FirstOrDefaultAsync(i => i.SixthPairID == id) != null) return null;
            if (await _context.Day.FirstOrDefaultAsync(i => i.SeventhPairID == id) != null) return null;
            _context.Pair.Remove(pair);
            await _context.SaveChangesAsync();
            return true;
        }
        public bool EntityExists(int id) => _context.Pair.Any(e => e.PairID == id);
        public async Task<Pair?> GetAsync(int id) => await _context.Pair.FindAsync(id);
        public async Task<IEnumerable<Pair>> GetListAsync() => await _context.Pair.ToListAsync();
        public async Task<bool> PostData(Pair entity)
        {
            _context.Pair.Add(entity);
            await _context.SaveChangesAsync();
            return true;
        }
        public async Task<bool?> PutData(int id, Pair entity)
        {
            if (id != entity.PairID) return false;

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
