using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Web_API_for_scheduling.Models.dto;
using Web_API_for_scheduling.Models.entities;
using Web_API_for_scheduling.Models.repositories;

namespace Web_API_for_scheduling.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GroupsController(IRepository<Group> repository, IMapper mapper) : ControllerBase, IController<GroupDto>
    {
        private readonly IRepository<Group> _repository = repository;
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
        public async Task<ActionResult<IEnumerable<GroupDto>>> GetListAsync()
        {
            var result = await _repository.GetListAsync();
            if (result == null) return NoContent();
            List<GroupDto> list = _mapper.Map<List<GroupDto>>(result);
            return list;
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<GroupDto>> GetRecordAsync(Guid id)
        {
            var record = await _repository.GetAsync(id);
            if (record == null) return NotFound();
            GroupDto dto = _mapper.Map<GroupDto>(record);
            return dto;
        }
        [HttpPost]
        public async Task<IActionResult> PostRecordAsync(GroupDto dto)
        {
            Group record = _mapper.Map<Group>(dto);
            await _repository.PostData(record);
            return Ok();
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRecordAsync(Guid id, GroupDto dto)
        {
            Group record = _mapper.Map<Group>(dto);
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
