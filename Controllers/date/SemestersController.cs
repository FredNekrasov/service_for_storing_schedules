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
        public async Task<ActionResult<IEnumerable<SemesterDto>>> GetListAsync()
        {
            var result = await _repository.GetListAsync();
            if (result == null) return NoContent();
            List<SemesterDto> list = _mapper.Map<List<SemesterDto>>(result);
            return list;
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<SemesterDto>> GetRecordAsync(Guid id)
        {
            var record = await _repository.GetAsync(id);
            if (record == null) return NotFound();
            SemesterDto dto = _mapper.Map<SemesterDto>(record);
            return dto;
        }
        [HttpPost]
        public async Task<IActionResult> PostRecordAsync(SemesterDto dto)
        {
            Semester record = _mapper.Map<Semester>(dto);
            await _repository.PostData(record);
            return Ok();
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRecordAsync(Guid id, SemesterDto dto)
        {
            Semester record = _mapper.Map<Semester>(dto);
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
