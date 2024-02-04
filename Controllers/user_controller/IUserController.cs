using API_for_mobile_app.model.entities;
using Microsoft.AspNetCore.Mvc;

namespace API_for_mobile_app.Controllers.user_controller
{
    public interface IUserController
    {
        ActionResult<IEnumerable<Users>> GetList();
        ActionResult<Users> GetRecord(Guid id);
        IActionResult PutRecord(Guid id, Users user);
        IActionResult PostRecord(Users user);
        IActionResult DeleteRecord(Guid id);
    }
}
