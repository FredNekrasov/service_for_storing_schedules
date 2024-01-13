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
        public IActionResult DeleteRecord(Guid id)
        {
            bool result = _repository.DeleteAsync(id).Result;
            if (!result) return NotFound();
            return Ok();
        }

        public ActionResult<IEnumerable<SubjectDto>> GetList()
        {
            var result = _repository.GetListAsync().Result;
            if (result == null) return NoContent();
            List<SubjectDto> list = _mapper.Map<List<SubjectDto>>(result);
            if (!ModelState.IsValid) return BadRequest(ModelState);
            return list;
        }

        public ActionResult<SubjectDto> GetRecord(Guid id)
        {
            var record = _repository.GetAsync(id).Result;
            if (record == null) return NotFound();
            SubjectDto dto = _mapper.Map<SubjectDto>(record);
            if (!ModelState.IsValid) return BadRequest(ModelState);
            return dto;
        }

        public IActionResult PostRecord(SubjectDto dto)
        {
            Subject record = _mapper.Map<Subject>(dto);
            bool result = _repository.PostData(record).Result;
            if (!result) return BadRequest();
            return Ok();
        }

        public IActionResult PutRecord(Guid id, SubjectDto dto)
        {
            Subject record = _mapper.Map<Subject>(dto);
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
