using API_for_mobile_app.Controllers;
using API_for_mobile_app.model.dto.date;
using API_for_mobile_app.model.entities.date;
using API_for_mobile_app.model.mappers;
using Microsoft.AspNetCore.Mvc;
using Web_API_for_scheduling.Models.repositories;

namespace Web_API_for_scheduling.Controllers.date;

[Route("api/[controller]")]
[ApiController]
public class DaysController(IRepository<Day> repository, IMapSpecialEntities<DayDto, Day> mapper) : ControllerBase, IController
{
    private readonly IRepository<Day> _repository = repository;
    private readonly IMapSpecialEntities<DayDto, Day> _mapper = mapper;
    [HttpGet]
    public ActionResult GetList()
    {
        List<DayDto> list = [];
        var result = _repository.GetList();
        if (result == null) return NoContent();
        foreach (var item in result)
        {
            list.Add(_mapper.ToDTO(item)!);
        }
        return Ok(list);
    }
}
