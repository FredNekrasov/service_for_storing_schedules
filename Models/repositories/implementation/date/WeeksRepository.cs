﻿using Microsoft.EntityFrameworkCore;
using Web_API_for_scheduling.models;
using Web_API_for_scheduling.Models.entities.date;

namespace Web_API_for_scheduling.Models.repositories.implementation.date
{
    public class WeeksRepository(TimetableDbContext context) : IRepository<Week>
    {
        private readonly TimetableDbContext _context = context;
        public async Task<bool?> DeleteAsync(int id)
        {
            var week = await _context.Week.FindAsync(id);
            if (week == null) return false;
            if (await _context.Day.FirstOrDefaultAsync(i => i.WeekID == id) != null) return null;
            _context.Week.Remove(week);
            await _context.SaveChangesAsync();
            return true;
        }
        public bool EntityExists(int id) => _context.Week.Any(e => e.ID == id);
        public async Task<Week?> GetAsync(int id) => await _context.Week.FindAsync(id);
        public async Task<IEnumerable<Week>> GetListAsync() => await _context.Week.ToListAsync();
        public async Task<bool> PostData(Week entity)
        {
            await _context.Week.AddAsync(entity);
            await _context.SaveChangesAsync();
            return true;
        }
        public async Task<bool?> PutData(int id, Week entity)
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
