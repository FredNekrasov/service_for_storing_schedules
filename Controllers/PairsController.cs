using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Web_API_for_scheduling.Models.entities;
using Web_API_for_scheduling.models;

namespace Web_API_for_scheduling.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PairsController(TimetableDbContext context) : ControllerBase
    {
        private readonly TimetableDbContext _context = context;

        // GET: api/Pairs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Pair>>> GetPair() => await _context.Pair.ToListAsync();

        // GET: api/Pairs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Pair>> GetPair(Guid id)
        {
            var pair = await _context.Pair.FindAsync(id);

            if (pair == null) return NotFound();

            return pair;
        }

        // PUT: api/Pairs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPair(Guid id, Pair pair)
        {
            if (id != pair.PairID) return BadRequest();

            _context.Entry(pair).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PairExists(id)) return NotFound(); else throw;
            }

            return NoContent();
        }

        // POST: api/Pairs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Pair>> PostPair(Pair pair)
        {
            _context.Pair.Add(pair);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPair", new { id = pair.PairID }, pair);
        }

        // DELETE: api/Pairs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePair(Guid id)
        {
            var pair = await _context.Pair.FindAsync(id);
            if (pair == null) return NotFound();

            _context.Pair.Remove(pair);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PairExists(Guid id) => _context.Pair.Any(e => e.PairID == id);
    }
}
