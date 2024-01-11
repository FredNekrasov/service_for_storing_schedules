using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Web_API_for_scheduling.Models.entities.date;
using Web_API_for_scheduling.models;

namespace Web_API_for_scheduling.Controllers.date
{
    [Route("api/[controller]")]
    [ApiController]
    public class SemestersController(TimetableDbContext context) : ControllerBase
    {
        private readonly TimetableDbContext _context = context;

        // GET: api/Semesters
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Semester>>> GetSemester() => await _context.Semester.ToListAsync();

        // GET: api/Semesters/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Semester>> GetSemester(Guid id)
        {
            var semester = await _context.Semester.FindAsync(id);

            if (semester == null) return NotFound();

            return semester;
        }

        // PUT: api/Semesters/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSemester(Guid id, Semester semester)
        {
            if (id != semester.ID) return BadRequest();
            
            _context.Entry(semester).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SemesterExists(id)) return NotFound(); else throw;
            }

            return NoContent();
        }

        // POST: api/Semesters
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Semester>> PostSemester(Semester semester)
        {
            _context.Semester.Add(semester);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSemester", new { id = semester.ID }, semester);
        }

        // DELETE: api/Semesters/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSemester(Guid id)
        {
            var semester = await _context.Semester.FindAsync(id);
            if (semester == null) return NotFound();

            _context.Semester.Remove(semester);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SemesterExists(Guid id) => _context.Semester.Any(e => e.ID == id);
    }
}
