using API_for_mobile_app.model.entities;
using API_for_mobile_app.model.repositories.user_repository;
using Microsoft.AspNetCore.Mvc;

namespace API_for_mobile_app.Controllers.user_controller.implementation
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController(IUserRepository repository) : ControllerBase, IUserController
    {
        private readonly IUserRepository _repository = repository;
        [HttpDelete("{id}")]
        public IActionResult DeleteRecord(Guid id)
        {
            bool result = _repository.DeleteAsync(id);
            if (result == false) return BadRequest();
            return Ok();
        }
        [HttpGet]
        public ActionResult<IEnumerable<Users>> GetList() => Ok((List<Users>)_repository.GetListAsync());
        [HttpGet("{id}")]
        public ActionResult<Users> GetRecord(Guid id)
        {
            var user = _repository.GetAsync(id);
            if (user == null) return NotFound();
            return Ok(user);
        }
        [HttpPost]
        public IActionResult PostRecord(Users user)
        {
            bool result = _repository.PostData(user);
            if (result == false) return BadRequest();
            return Ok();
        }
        [HttpPut("{id}")]
        public IActionResult PutRecord(Guid id, Users user)
        {
            bool? result = _repository.PutData(id, user);
            return result switch
            {
                false => BadRequest(),
                null => NotFound(),
                true => NoContent(),
            };
        }
    }
}
