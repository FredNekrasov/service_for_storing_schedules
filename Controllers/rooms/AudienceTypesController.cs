using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Web_API_for_scheduling.Models.dto.rooms;
using Web_API_for_scheduling.Models.entities.rooms;
using Web_API_for_scheduling.Models.repositories;

namespace Web_API_for_scheduling.Controllers.rooms
{
    [Route("api/[controller]")]
    [ApiController]
    public class AudienceTypesController(IRepository<AudienceType> repository, IMapper mapper) : ControllerBase, IController<AudienceTypeDto>
    {
        private readonly IRepository<AudienceType> _repository = repository;
        private readonly IMapper _mapper = mapper;
        [HttpDelete("{id}")]
        public IActionResult DeleteRecord(Guid id)
        {
            bool result = _repository.DeleteAsync(id).Result;
            if (!result) return NotFound();
            return Ok();
        }
        [HttpGet]
        public ActionResult<IEnumerable<AudienceTypeDto>> GetList()
        {
            var result = _repository.GetListAsync().Result;
            if (result == null) return NoContent();
            List<AudienceTypeDto> list = _mapper.Map<List<AudienceTypeDto>>(result);
            if (!ModelState.IsValid) return BadRequest(ModelState);
            return list;
        }
        [HttpGet("{id}")]
        public ActionResult<AudienceTypeDto> GetRecord(Guid id)
        {
            var record = _repository.GetAsync(id).Result;
            if (record == null) return NotFound();
            AudienceTypeDto dto = _mapper.Map<AudienceTypeDto>(record);
            if (!ModelState.IsValid) return BadRequest(ModelState);
            return dto;
        }
        [HttpPost]
        public IActionResult PostRecord(AudienceTypeDto dto)
        {
            AudienceType record = _mapper.Map<AudienceType>(dto);
            bool result = _repository.PostData(record).Result;
            if (!result) return BadRequest();
            return Ok();
        }
        [HttpPut("{id}")]
        public IActionResult PutRecord(Guid id, AudienceTypeDto dto)
        {
            AudienceType record = _mapper.Map<AudienceType>(dto);
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
