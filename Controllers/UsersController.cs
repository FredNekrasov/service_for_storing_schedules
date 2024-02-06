using Microsoft.AspNetCore.Mvc;
using Web_API_for_scheduling.Models.entities;
using Web_API_for_scheduling.Models.repositories;

namespace Web_API_for_scheduling.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UsersController(IRepository<Users> repository) : ControllerBase
{
    private readonly IRepository<Users> _repository = repository;

    // GET: api/Users
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Users>>> GetUsers() => Ok((List<Users>)await _repository.GetListAsync());

    // GET: api/Users/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Users>> GetUser(int id)
    {
        var user = await _repository.GetAsync(id);
        if (user == null) return NotFound();
        return Ok(user);
    }

    // PUT: api/Users/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{id}")]
    public async Task<IActionResult> PutUser(int id, Users user)
    {
        bool? result = await _repository.PutData(id, user);
        return result switch
        {
            false => BadRequest(),
            null => NotFound(),
            true => NoContent(),
        };
    }

    // POST: api/Users
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<Users>> PostUsers(Users users)
    {
        bool result = await _repository.PostData(users);
        if (result == false) return BadRequest();
        return Ok();
    }

    // DELETE: api/Users/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteUsers(int id)
    {
        bool? result = await _repository.DeleteAsync(id);
        if (result == false) return BadRequest();
        return Ok();
    }
}
