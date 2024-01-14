using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Web_API_for_scheduling.Models.dto;
using Web_API_for_scheduling.Models.entities;
using Web_API_for_scheduling.Models.repositories;
namespace Web_API_for_scheduling.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubjectsController(IRepository<Subject> repository, IMapper mapper) : ControllerBase, IController<SubjectDto>
    {
        private readonly IRepository<Subject> _repository = repository;
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
        public async Task<ActionResult<IEnumerable<SubjectDto>>> GetListAsync()
        {
            var result = await _repository.GetListAsync();
            if (result == null) return NoContent();
            List<SubjectDto> list = _mapper.Map<List<SubjectDto>>(result);
            return list;
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<SubjectDto>> GetRecordAsync(Guid id)
        {
            var record = await _repository.GetAsync(id);
            if (record == null) return NotFound();
            SubjectDto dto = _mapper.Map<SubjectDto>(record);
            return dto;
        }
        [HttpPost]
        public async Task<IActionResult> PostRecordAsync(SubjectDto dto)
        {
            Subject record = _mapper.Map<Subject>(dto);
            await _repository.PostData(record);
            return Ok();
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRecordAsync(Guid id, SubjectDto dto)
        {
            Subject record = _mapper.Map<Subject>(dto);
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
