using Microsoft.AspNetCore.Mvc;
using Web_API_for_scheduling.Models.dto;
using Web_API_for_scheduling.Models.entities;
using Web_API_for_scheduling.Models.mappers.pair;
using Web_API_for_scheduling.Models.repositories;

namespace Web_API_for_scheduling.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PairsController(IRepository<Pair> repository, IMapPair mapper) : ControllerBase, IController<PairDto>
{
    private readonly IRepository<Pair> _repository = repository;
    private readonly IMapPair _mapper = mapper;
    private PairDto? dto;
    private readonly List<PairDto> list = [];
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteRecordAsync(Guid id)
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
    public async Task<ActionResult<IEnumerable<PairDto>>> GetListAsync()
    {
        var result = await _repository.GetListAsync();
        if (result == null) return NoContent();
        foreach (var item in result)
        {
            dto = await _mapper.ToDtoAsync(item);
            list.Add(dto!);
        }
        return Ok(dto);
    }
    [HttpGet("{id}")]
    public async Task<ActionResult<PairDto>> GetRecordAsync(Guid id)
    {
        var record = await _repository.GetAsync(id);
        if (record == null) return NotFound();
        dto = await _mapper.ToDtoAsync(record);
        if (dto == null) return NotFound();
        return Ok(dto);
    }
    [HttpPost]
    public async Task<IActionResult> PostRecordAsync(PairDto dto)
    {
        bool result = _repository.EntityExists(dto.PairID);
        if (result) return BadRequest();
        Pair? record = _mapper.ToPair(dto);
        if (record == null) return BadRequest();
        await _repository.PostData(record);
        return Ok();
    }
    [HttpPut("{id}")]
    public async Task<IActionResult> PutRecordAsync(Guid id, PairDto dto)
    {
        Pair? record = _mapper.ToPair(dto);
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
