using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Web_API_for_scheduling.Models.dto;
using Web_API_for_scheduling.Models.entities;
using Web_API_for_scheduling.Models.repositories;
namespace Web_API_for_scheduling.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeachersController(IRepository<Teacher> repository, IMapper mapper) : ControllerBase, IController<TeacherDto>
    {
        private readonly IRepository<Teacher> _repository = repository;
        private readonly IMapper _mapper = mapper;
        public IActionResult DeleteRecord(Guid id)
        {
            bool result = _repository.DeleteAsync(id).Result;
            if (!result) return NotFound();
            return Ok();
        }

        public ActionResult<IEnumerable<TeacherDto>> GetList()
        {
            var result = _repository.GetListAsync().Result;
            if (result == null) return NoContent();
            List<TeacherDto> list = _mapper.Map<List<TeacherDto>>(result);
            if (!ModelState.IsValid) return BadRequest(ModelState);
            return list;
        }

        public ActionResult<TeacherDto> GetRecord(Guid id)
        {
            var record = _repository.GetAsync(id).Result;
            if (record == null) return NotFound();
            TeacherDto dto = _mapper.Map<TeacherDto>(record);
            if (!ModelState.IsValid) return BadRequest(ModelState);
            return dto;
        }

        public IActionResult PostRecord(TeacherDto dto)
        {
            Teacher record = _mapper.Map<Teacher>(dto);
            bool result = _repository.PostData(record).Result;
            if (!result) return BadRequest();
            return Ok();
        }

        public IActionResult PutRecord(Guid id, TeacherDto dto)
        {
            Teacher record = _mapper.Map<Teacher>(dto);
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
