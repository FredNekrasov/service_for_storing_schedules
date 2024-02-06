using Microsoft.AspNetCore.Mvc;

namespace Web_API_for_scheduling.Controllers
{
    public interface IController<T>
    {
        Task<ActionResult<IEnumerable<T>>> GetListAsync();
        Task<ActionResult<T>> GetRecordAsync(int id);
        Task<IActionResult> PutRecordAsync(int id, T dto);
        Task<IActionResult> PostRecordAsync(T dto);
        Task<IActionResult> DeleteRecordAsync(int id);
    }
}
