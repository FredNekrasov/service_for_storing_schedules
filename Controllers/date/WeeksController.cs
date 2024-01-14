using Microsoft.AspNetCore.Mvc;
using Web_API_for_scheduling.Models.dto.date;
using Web_API_for_scheduling.Models.entities.date;
using Web_API_for_scheduling.Models.mappers.week;
using Web_API_for_scheduling.Models.repositories;

namespace Web_API_for_scheduling.Controllers.date
{
    [Route("api/[controller]")]
    [ApiController]
    public class WeeksController(IRepository<Week> repository, IMapWeek mapper) : ControllerBase, IController<WeekDto>
    {
        private readonly IRepository<Week> _repository = repository;
        private readonly IMapWeek _mapper = mapper;
        private WeekDto? weekDto;
        private readonly List<WeekDto> list = [];
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
        public async Task<ActionResult<IEnumerable<WeekDto>>> GetListAsync()
        {
            var result = await _repository.GetListAsync();
            if (result == null) return NoContent();
            foreach (var item in result)
            {
                weekDto = await _mapper.ToDtoAsync(item);
                list.Add(weekDto!);
            }
            return list;
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<WeekDto>> GetRecordAsync(Guid id)
        {
            Week? record = await _repository.GetAsync(id);
            if (record == null) return NotFound();
            weekDto = await _mapper.ToDtoAsync(record);
            if (weekDto == null) return NotFound();
            return weekDto;
        }
        [HttpPost]
        public async Task<IActionResult> PostRecordAsync(WeekDto dto)
        {
            bool result = _repository.EntityExists(dto.ID);
            if (result) return BadRequest();
            Week? record = _mapper.ToWeek(dto);
            if (record == null) return BadRequest();
            await _repository.PostData(record);
            return Ok();
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRecordAsync(Guid id, WeekDto dto)
        {
            Week? record = _mapper.ToWeek(dto);
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
