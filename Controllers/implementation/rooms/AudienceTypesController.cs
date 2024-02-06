using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Web_API_for_scheduling.Models.dto.rooms;
using Web_API_for_scheduling.Models.entities.rooms;
using Web_API_for_scheduling.Models.repositories;

namespace Web_API_for_scheduling.Controllers.implementation.rooms;

[Route("api/[controller]")]
[ApiController]
public class AudienceTypesController(IRepository<AudienceType> repository, IMapper mapper) : ControllerBase, IController<AudienceTypeDto>
{
    private readonly IRepository<AudienceType> _repository = repository;
    private readonly IMapper _mapper = mapper;
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
    public async Task<ActionResult<IEnumerable<AudienceTypeDto>>> GetListAsync()
    {
        var result = await _repository.GetListAsync();
        if (result == null) return NoContent();
        List<AudienceTypeDto> list = _mapper.Map<List<AudienceTypeDto>>(result);
        return Ok(list);
    }
    [HttpGet("{id}")]
    public async Task<ActionResult<AudienceTypeDto>> GetRecordAsync(int id)
    {
        var record = await _repository.GetAsync(id);
        if (record == null) return NotFound();
        AudienceTypeDto dto = _mapper.Map<AudienceTypeDto>(record);
        return Ok(dto);
    }
    [HttpPost]
    public async Task<IActionResult> PostRecordAsync(AudienceTypeDto dto)
    {
        AudienceType record = _mapper.Map<AudienceType>(dto);
        await _repository.PostData(record);
        return Ok();
    }
    [HttpPut("{id}")]
    public async Task<IActionResult> PutRecordAsync(int id, AudienceTypeDto dto)
    {
        AudienceType record = _mapper.Map<AudienceType>(dto);
        bool? result = await _repository.PutData(id, record);
        return result switch
        {
            false => BadRequest(),
            null => NotFound(),
            true => NoContent(),
        };
    }
}
