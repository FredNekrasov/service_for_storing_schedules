using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Web_API_for_scheduling.Models.entities.rooms;
using Web_API_for_scheduling.models;

namespace Web_API_for_scheduling.Controllers.rooms
{
    [Route("api/[controller]")]
    [ApiController]
    public class AudienceTypesController(TimetableDbContext context) : ControllerBase
    {
        private readonly TimetableDbContext _context = context;

        // GET: api/AudienceTypes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AudienceType>>> GetAudienceType() => await _context.AudienceType.ToListAsync();

        // GET: api/AudienceTypes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AudienceType>> GetAudienceType(Guid id)
        {
            var audienceType = await _context.AudienceType.FindAsync(id);

            if (audienceType == null) return NotFound();

            return audienceType;
        }

        // PUT: api/AudienceTypes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAudienceType(Guid id, AudienceType audienceType)
        {
            if (id != audienceType.ID) return BadRequest();

            _context.Entry(audienceType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AudienceTypeExists(id)) return NotFound(); else throw;
            }

            return NoContent();
        }

        // POST: api/AudienceTypes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<AudienceType>> PostAudienceType(AudienceType audienceType)
        {
            _context.AudienceType.Add(audienceType);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAudienceType", new { id = audienceType.ID }, audienceType);
        }

        // DELETE: api/AudienceTypes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAudienceType(Guid id)
        {
            var audienceType = await _context.AudienceType.FindAsync(id);
            if (audienceType == null) return NotFound();

            _context.AudienceType.Remove(audienceType);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AudienceTypeExists(Guid id) => _context.AudienceType.Any(e => e.ID == id);
    }
}
