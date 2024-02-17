using Microsoft.AspNetCore.Mvc;
using Web_API_for_scheduling.Models.dto.rooms;
using Web_API_for_scheduling.Models.entities.rooms;
using Web_API_for_scheduling.Models.mappers;
using Web_API_for_scheduling.Models.repositories;

namespace Web_API_for_scheduling.Controllers.implementation.rooms;

[Route("api/[controller]")]
[ApiController]
public class AudiencesController(IRepository<Audience> repository, IMapSE<Audience, AudienceDto> mapper) : ControllerBase, IController<AudienceDto>
{
    private readonly IRepository<Audience> _repository = repository;
    private readonly IMapSE<Audience, AudienceDto> _mapper = mapper;
    private AudienceDto? dto;
    private readonly List<AudienceDto> list = [];
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteRecordAsync(int id)
    {
        bool? result = await _repository.DeleteAsync(id);
        return result switch
        {
            false => NotFound(),
            null => BadRequest("this record is used as a foreign key in other entities"),
            true => Ok()
        };
    }
    [HttpGet]
    public async Task<ActionResult<IEnumerable<AudienceDto>>> GetListAsync()
    {
        var result = await _repository.GetListAsync();
        if (result == null) return NoContent();
        foreach (var item in result)
        {
            dto = await _mapper.ToDtoAsync(item);
            list.Add(dto!);
        }
        return Ok(list);
    }
    [HttpGet("{id}")]
    public async Task<ActionResult<AudienceDto>> GetRecordAsync(int id)
    {
        var record = await _repository.GetAsync(id);
        if (record == null) return NotFound();
        dto = await _mapper.ToDtoAsync(record);
        if (dto == null) return NotFound();
        return Ok(dto);
    }
    [HttpPost]
    public async Task<IActionResult> PostRecordAsync(AudienceDto dto)
    {
        bool result = _repository.EntityExists(dto.ID);
        if (result) return BadRequest();
        Audience? record = _mapper.ToEntity(dto);
        if (record == null) return BadRequest();
        await _repository.PostData(record);
        return Ok();
    }
    [HttpPut("{id}")]
    public async Task<IActionResult> PutRecordAsync(int id, AudienceDto dto)
    {
        Audience? record = _mapper.ToEntity(dto);
        if (record == null) return BadRequest();
        bool? result = await _repository.PutData(id, record);
        return result switch
        {
            false => BadRequest(),
            null => NotFound(),
            true => NoContent(),
        };
    }
}
