using API_for_mobile_app.model.entities;
using API_for_mobile_app.model.repositories.user_repository;
using Microsoft.AspNetCore.Mvc;

namespace API_for_mobile_app.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController(IUserRepository repository) : ControllerBase
    {
        private readonly IUserRepository _repository = repository;
        [HttpGet]
        public ActionResult GetList() => Ok((List<Users>)_repository.GetListAsync());
        [HttpGet("{id}")]
        public ActionResult<Users> GetUser(int id)
        {
            var user = _repository.GetAsync(id);
            if (user == null) return NotFound();
            return Ok(user);
        }

        // PUT: api/Users/5
        [HttpPut("{id}")]
        public IActionResult PutUser(int id, Users user)
        {
            bool? result = _repository.PutData(id, user);
            return result switch
            {
                false => BadRequest(),
                null => NotFound(),
                true => NoContent(),
            };
        }

        // POST: api/Users
        [HttpPost]
        public ActionResult<Users> PostUsers(Users users)
        {
            bool result = _repository.PostData(users);
            if (result == false) return BadRequest();
            return Ok();
        }

        // DELETE: api/Users/5
        [HttpDelete("{id}")]
        public IActionResult DeleteUsers(int id)
        {
            bool result = _repository.DeleteAsync(id);
            if (result == false) return BadRequest();
            return Ok();
        }
    }
}
