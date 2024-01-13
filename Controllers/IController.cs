using Microsoft.AspNetCore.Mvc;

namespace Web_API_for_scheduling.Controllers
{
    public interface IController<T>
    {
        ActionResult<IEnumerable<T>> GetList();
        ActionResult<T> GetRecord(Guid id);
        IActionResult PutRecord(Guid id, T dto);
        IActionResult PostRecord(T dto);
        IActionResult DeleteRecord(Guid id);
    }
}
