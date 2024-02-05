using API_for_mobile_app.model.entities;
using API_for_mobile_app.model.repositories.user_repository;
using Microsoft.AspNetCore.Mvc;

namespace API_for_mobile_app.Controllers.implementation
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController(IUserRepository repository) : ControllerBase, IController
    {
        private readonly IUserRepository _repository = repository;
        [HttpGet]
        public ActionResult GetList() => Ok((List<Users>)_repository.GetListAsync());
    }
}
