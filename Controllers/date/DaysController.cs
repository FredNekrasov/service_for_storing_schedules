using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Web_API_for_scheduling.Models.dto.date;
using Web_API_for_scheduling.Models.entities.date;
using Web_API_for_scheduling.Models.repositories;

namespace Web_API_for_scheduling.Controllers.date
{
    [Route("api/[controller]")]
    [ApiController]
    public class DaysController(IRepository<Day> repository, IMapper mapper) : ControllerBase, IController<DayDto>
    {
        private readonly IRepository<Day> _repository = repository;
        private readonly IMapper _mapper = mapper;
        [HttpDelete("{id}")]
        public IActionResult DeleteRecord(Guid id)
        {
            bool result = _repository.DeleteAsync(id).Result;
            if (!result) return NotFound();
            return Ok();
        }
        [HttpGet]
        public ActionResult<IEnumerable<DayDto>> GetList()
        {
            var result = _repository.GetListAsync().Result;
            if (result == null) return NoContent();
            List<DayDto> list = _mapper.Map<List<DayDto>>(result);
            if (!ModelState.IsValid) return BadRequest(ModelState);
            return list;
        }
        [HttpGet("{id}")]
        public ActionResult<DayDto> GetRecord(Guid id)
        {
            var record = _repository.GetAsync(id).Result;
            if (record == null) return NotFound();
            DayDto dto = _mapper.Map<DayDto>(record);
            if (!ModelState.IsValid) return BadRequest(ModelState);
            return dto;
        }
        [HttpPost]
        public IActionResult PostRecord(DayDto dto)
        {
            Day record = _mapper.Map<Day>(dto);
            bool result = _repository.PostData(record).Result;
            if (!result) return BadRequest();
            return Ok();
        }
        [HttpPut("{id}")]
        public IActionResult PutRecord(Guid id, DayDto dto)
        {
            Day record = _mapper.Map<Day>(dto);
            bool? result = _repository.PutData(id, record).Result;
            return result switch
            {
                false => BadRequest(),
                null => NotFound(),
                true => NoContent(),
            };
        }
    }
}
