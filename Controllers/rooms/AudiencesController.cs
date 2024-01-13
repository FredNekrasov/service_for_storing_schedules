using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Web_API_for_scheduling.Models.dto.rooms;
using Web_API_for_scheduling.Models.entities.rooms;
using Web_API_for_scheduling.Models.repositories;

namespace Web_API_for_scheduling.Controllers.rooms
{
    [Route("api/[controller]")]
    [ApiController]
    public class AudiencesController(IRepository<Audience> repository, IMapper mapper) : ControllerBase, IController<AudienceDto>
    {
        private readonly IRepository<Audience> _repository = repository;
        private readonly IMapper _mapper = mapper;
        [HttpDelete("{id}")]
        public IActionResult DeleteRecord(Guid id)
        {
            bool result = _repository.DeleteAsync(id).Result;
            if (!result) return NotFound();
            return Ok();
        }
        [HttpGet]
        public ActionResult<IEnumerable<AudienceDto>> GetList()
        {
            var result = _repository.GetListAsync().Result;
            if (result == null) return NoContent();
            List<AudienceDto> list = _mapper.Map<List<AudienceDto>>(result);
            if (!ModelState.IsValid) return BadRequest(ModelState);
            return list;
        }
        [HttpGet("{id}")]
        public ActionResult<AudienceDto> GetRecord(Guid id)
        {
            var record = _repository.GetAsync(id).Result;
            if (record == null) return NotFound();
            AudienceDto dto = _mapper.Map<AudienceDto>(record);
            if (!ModelState.IsValid) return BadRequest(ModelState);
            return dto;
        }
        [HttpPost]
        public IActionResult PostRecord(AudienceDto dto)
        {
            Audience record = _mapper.Map<Audience>(dto);
            bool result = _repository.PostData(record).Result;
            if (!result) return BadRequest();
            return Ok();
        }
        [HttpPut("{id}")]
        public IActionResult PutRecord(Guid id, AudienceDto dto)
        {
            Audience record = _mapper.Map<Audience>(dto);
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
