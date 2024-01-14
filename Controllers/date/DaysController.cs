using Microsoft.AspNetCore.Mvc;
using Web_API_for_scheduling.Models.dto.date;
using Web_API_for_scheduling.Models.entities.date;
using Web_API_for_scheduling.Models.mappers.day;
using Web_API_for_scheduling.Models.repositories;

namespace Web_API_for_scheduling.Controllers.date
{
    [Route("api/[controller]")]
    [ApiController]
    public class DaysController(IRepository<Day> repository, IMapDay mapper) : ControllerBase, IController<DayDto>
    {
        private readonly IRepository<Day> _repository = repository;
        private readonly IMapDay _mapper = mapper;
        private DayDto? dto;
        private readonly List<DayDto> list = [];
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRecordAsync(Guid id)
        {
            bool result = await _repository.DeleteAsync(id);
            if (!result) return NotFound();
            return Ok();
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DayDto>>> GetListAsync()
        {
            var result = await _repository.GetListAsync();
            if (result == null) return NoContent();
            foreach (var item in result)
            {
                dto = await _mapper.ToDtoAsync(item);
                list.Add(dto!);
            }
            return list;
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<DayDto>> GetRecordAsync(Guid id)
        {
            var record = await _repository.GetAsync(id);
            if (record == null) return NotFound();
            dto = await _mapper.ToDtoAsync(record);
            if (dto == null) return NotFound();
            return dto;
        }
        [HttpPost]
        public async Task<IActionResult> PostRecordAsync(DayDto dto)
        {
            bool result = _repository.EntityExists(dto.ID);
            if (result) return BadRequest();
            Day? record = _mapper.ToDay(dto);
            if (record == null) return BadRequest();
            await _repository.PostData(record);
            return Ok();
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRecordAsync(Guid id, DayDto dto)
        {
            Day? record = _mapper.ToDay(dto);
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
}
