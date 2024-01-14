using Microsoft.AspNetCore.Mvc;

namespace Web_API_for_scheduling.Controllers
{
    public interface IController<T>
    {
        Task<ActionResult<IEnumerable<T>>> GetListAsync();
        Task<ActionResult<T>> GetRecordAsync(Guid id);
        Task<IActionResult> PutRecordAsync(Guid id, T dto);
        Task<IActionResult> PostRecordAsync(T dto);
        Task<IActionResult> DeleteRecordAsync(Guid id);
    }
}
