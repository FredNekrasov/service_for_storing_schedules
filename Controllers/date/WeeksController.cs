using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Web_API_for_scheduling.Models.entities.date;
using Web_API_for_scheduling.models;

namespace Web_API_for_scheduling.Controllers.date
{
    [Route("api/[controller]")]
    [ApiController]
    public class WeeksController(TimetableDbContext context) : ControllerBase
    {
        private readonly TimetableDbContext _context = context;

        // GET: api/Weeks
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Week>>> GetWeek() => await _context.Week.ToListAsync();

        // GET: api/Weeks/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Week>> GetWeek(Guid id)
        {
            var week = await _context.Week.FindAsync(id);

            if (week == null) return NotFound();

            return week;
        }

        // PUT: api/Weeks/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutWeek(Guid id, Week week)
        {
            if (id != week.ID) return BadRequest();

            _context.Entry(week).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WeekExists(id)) return NotFound(); else throw;
            }

            return NoContent();
        }

        // POST: api/Weeks
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Week>> PostWeek(Week week)
        {
            _context.Week.Add(week);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetWeek", new { id = week.ID }, week);
        }

        // DELETE: api/Weeks/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteWeek(Guid id)
        {
            var week = await _context.Week.FindAsync(id);
            if (week == null) return NotFound();

            _context.Week.Remove(week);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool WeekExists(Guid id) => _context.Week.Any(e => e.ID == id);
    }
}
