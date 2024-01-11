using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Web_API_for_scheduling.Models.entities.rooms;
using Web_API_for_scheduling.models;

namespace Web_API_for_scheduling.Controllers.rooms
{
    [Route("api/[controller]")]
    [ApiController]
    public class AudiencesController(TimetableDbContext context) : ControllerBase
    {
        private readonly TimetableDbContext _context = context;

        // GET: api/Audiences
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Audience>>> GetAudience() => await _context.Audience.ToListAsync();

        // GET: api/Audiences/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Audience>> GetAudience(Guid id)
        {
            var audience = await _context.Audience.FindAsync(id);
            if (audience == null) return NotFound();
            return audience;
        }

        // PUT: api/Audiences/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAudience(Guid id, Audience audience)
        {
            if (id != audience.ID) return BadRequest();

            _context.Entry(audience).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AudienceExists(id)) return NotFound(); else throw;
            }

            return NoContent();
        }

        // POST: api/Audiences
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Audience>> PostAudience(Audience audience)
        {
            _context.Audience.Add(audience);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAudience", new { id = audience.ID }, audience);
        }

        // DELETE: api/Audiences/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAudience(Guid id)
        {
            var audience = await _context.Audience.FindAsync(id);
            if (audience == null) return NotFound();

            _context.Audience.Remove(audience);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AudienceExists(Guid id) => _context.Audience.Any(e => e.ID == id);
    }
}
