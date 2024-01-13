using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Web_API_for_scheduling.Models.dto.date;
using Web_API_for_scheduling.Models.entities.date;
using Web_API_for_scheduling.Models.repositories;

namespace Web_API_for_scheduling.Controllers.date
{
    [Route("api/[controller]")]
    [ApiController]
    public class WeeksController(IRepository<Week> repository, IMapper mapper) : ControllerBase, IController<WeekDto>
    {
        private readonly IRepository<Week> _repository = repository;
        private readonly IMapper _mapper = mapper;
        [HttpDelete("{id}")]
        public IActionResult DeleteRecord(Guid id)
        {
            bool result = _repository.DeleteAsync(id).Result;
            if (!result) return NotFound();
            return Ok();
        }
        [HttpGet]
        public ActionResult<IEnumerable<WeekDto>> GetList()
        {
            var result = _repository.GetListAsync().Result;
            if (result == null) return NoContent();
            List<WeekDto> list = _mapper.Map<List<WeekDto>>(result);
            if (!ModelState.IsValid) return BadRequest(ModelState);
            return list;
        }
        [HttpGet("{id}")]
        public ActionResult<WeekDto> GetRecord(Guid id)
        {
            var record = _repository.GetAsync(id).Result;
            if (record == null) return NotFound();
            WeekDto dto = _mapper.Map<WeekDto>(record);
            if (!ModelState.IsValid) return BadRequest(ModelState);
            return dto;
        }
        [HttpPost]
        public IActionResult PostRecord(WeekDto dto)
        {
            Week record = _mapper.Map<Week>(dto);
            bool result = _repository.PostData(record).Result;
            if (!result) return BadRequest();
            return Ok();
        }
        [HttpPut("{id}")]
        public IActionResult PutRecord(Guid id, WeekDto dto)
        {
            Week record = _mapper.Map<Week>(dto);
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
