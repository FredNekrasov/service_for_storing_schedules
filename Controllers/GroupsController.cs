using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Web_API_for_scheduling.Models.entities;
using Web_API_for_scheduling.models;

namespace Web_API_for_scheduling.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GroupsController(TimetableDbContext context) : ControllerBase
    {
        private readonly TimetableDbContext _context = context;

        // GET: api/Groups
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Group>>> GetGroup() => await _context.Group.ToListAsync();

        // GET: api/Groups/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Group>> GetGroup(Guid id)
        {
            var squad = await _context.Group.FindAsync(id);

            if (squad == null) return NotFound();

            return squad;
        }

        // PUT: api/Groups/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGroup(Guid id, Group squad)
        {
            if (id != squad.ID) return BadRequest();

            _context.Entry(squad).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GroupExists(id)) return NotFound(); else throw;
            }

            return NoContent();
        }

        // POST: api/Groups
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Group>> PostGroup(Group squad)
        {
            _context.Group.Add(squad);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGroup", new { id = squad.ID }, squad);
        }

        // DELETE: api/Groups/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGroup(Guid id)
        {
            var squad = await _context.Group.FindAsync(id);
            if (squad == null) return NotFound();

            _context.Group.Remove(squad);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool GroupExists(Guid id) => _context.Group.Any(e => e.ID == id);
    }
}
