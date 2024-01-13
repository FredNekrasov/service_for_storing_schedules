using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Web_API_for_scheduling.Models.entities.date;
using Web_API_for_scheduling.Models.dto.date;
using Web_API_for_scheduling.Models.repositories;

namespace Web_API_for_scheduling.Controllers.date
{
    [Route("api/[controller]")]
    [ApiController]
    public class SemestersController(IRepository<Semester> repository, IMapper mapper) : ControllerBase, IController<SemesterDto>
    {
        private readonly IRepository<Semester> _repository = repository;
        private readonly IMapper _mapper = mapper;
        [HttpDelete("{id}")]
        public IActionResult DeleteRecord(Guid id)
        {
            bool result = _repository.DeleteAsync(id).Result;
            if (!result) return NotFound();
            return Ok();
        }
        [HttpGet]
        public ActionResult<IEnumerable<SemesterDto>> GetList()
        {
            var result = _repository.GetListAsync().Result;
            if (result == null) return NoContent();
            List<SemesterDto> list = _mapper.Map<List<SemesterDto>>(result);
            if (!ModelState.IsValid) return BadRequest(ModelState);
            return list;
        }
        [HttpGet("{id}")]
        public ActionResult<SemesterDto> GetRecord(Guid id)
        {
            var record = _repository.GetAsync(id).Result;
            if (record == null) return NotFound();
            SemesterDto dto = _mapper.Map<SemesterDto>(record);
            if (!ModelState.IsValid) return BadRequest(ModelState);
            return dto;
        }
        [HttpPost]
        public IActionResult PostRecord(SemesterDto dto)
        {
            Semester record = _mapper.Map<Semester>(dto);
            bool result = _repository.PostData(record).Result;
            if(!result) return BadRequest();
            return Ok();
        }
        [HttpPut("{id}")]
        public IActionResult PutRecord(Guid id, SemesterDto dto)
        {
            Semester record = _mapper.Map<Semester>(dto);
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
