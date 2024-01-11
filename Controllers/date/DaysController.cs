using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Web_API_for_scheduling.Models.entities.date;
using Web_API_for_scheduling.models;

namespace Web_API_for_scheduling.Controllers.date
{
    [Route("api/[controller]")]
    [ApiController]
    public class DaysController(TimetableDbContext context) : ControllerBase
    {
        private readonly TimetableDbContext _context = context;

        // GET: api/Days
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Day>>> GetDay() => await _context.Day.ToListAsync();

        // GET: api/Days/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Day>> GetDay(Guid id)
        {
            var day = await _context.Day.FindAsync(id);

            if (day == null) return NotFound();
            
            return day;
        }

        // PUT: api/Days/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDay(Guid id, Day day)
        {
            if (id != day.ID) return BadRequest();
            
            _context.Entry(day).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DayExists(id)) return NotFound(); else throw;
            }

            return NoContent();
        }

        // POST: api/Days
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Day>> PostDay(Day day)
        {
            _context.Day.Add(day);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDay", new { id = day.ID }, day);
        }

        // DELETE: api/Days/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDay(Guid id)
        {
            var day = await _context.Day.FindAsync(id);
            if (day == null) return NotFound();

            _context.Day.Remove(day);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DayExists(Guid id) => _context.Day.Any(e => e.ID == id);
    }
}
