using API_for_mobile_app.Controllers;
using API_for_mobile_app.model.dto.rooms;
using API_for_mobile_app.model.entities.rooms;
using API_for_mobile_app.model.mappers;
using Microsoft.AspNetCore.Mvc;
using Web_API_for_scheduling.Models.repositories;

namespace Web_API_for_scheduling.Controllers.rooms;

[Route("api/[controller]")]
[ApiController]
public class AudiencesController(IRepository<Audience> repository, IMapSpecialEntities<AudienceDto, Audience> mapper) : ControllerBase, IController<AudienceDto>
{
    private readonly IRepository<Audience> _repository = repository;
    private readonly IMapSpecialEntities<AudienceDto, Audience> _mapper = mapper;
    [HttpGet]
    public ActionResult<IEnumerable<AudienceDto>> GetList()
    {
        List<AudienceDto> list = [];
        var result = _repository.GetList();
        if (result == null) return NoContent();
        foreach (var item in result)
        {
            list.Add(_mapper.ToDTO(item)!);
        }
        return Ok(list);
    }
}
