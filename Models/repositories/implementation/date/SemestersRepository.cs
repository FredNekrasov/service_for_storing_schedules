﻿using Microsoft.EntityFrameworkCore;
using Web_API_for_scheduling.models;
using Web_API_for_scheduling.Models.entities.date;

namespace Web_API_for_scheduling.Models.repositories.implementation.date;
public class SemestersRepository(TimetableDbContext context) : IRepository<Semester>
{
    private readonly TimetableDbContext _context = context;
    public async Task<bool?> DeleteAsync(int id)
    {
        var semester = await _context.Semester.FindAsync(id);
        if (semester == null) return false;
        if (await _context.Week.FirstAsync(i => i.SemesterID == id) != null) return null;
        _context.Semester.Remove(semester);
        await _context.SaveChangesAsync();
        return true;
    }
    public async Task<Semester?> GetAsync(int id) => await _context.Semester.FindAsync(id);
    public async Task<IEnumerable<Semester>> GetListAsync() => await _context.Semester.ToListAsync();
    public async Task<bool?> PutData(int id, Semester entity)
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
    public bool EntityExists(int id) => _context.Semester.Any(e => e.ID == id);
    public async Task<bool> PostData(Semester entity)
    {
        await _context.Semester.AddAsync(entity);
        await _context.SaveChangesAsync();
        return true;
    }
}
