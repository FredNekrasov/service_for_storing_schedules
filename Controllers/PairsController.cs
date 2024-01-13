using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Web_API_for_scheduling.Models.dto;
using Web_API_for_scheduling.Models.entities;
using Web_API_for_scheduling.Models.repositories;

namespace Web_API_for_scheduling.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PairsController(IRepository<Pair> repository, IMapper mapper) : ControllerBase, IController<PairDto>
    {
        private readonly IRepository<Pair> _repository = repository;
        private readonly IMapper _mapper = mapper;
        public IActionResult DeleteRecord(Guid id)
        {
            bool result = _repository.DeleteAsync(id).Result;
            if (!result) return NotFound();
            return Ok();
        }

        public ActionResult<IEnumerable<PairDto>> GetList()
        {
            var result = _repository.GetListAsync().Result;
            if (result == null) return NoContent();
            List<PairDto> list = _mapper.Map<List<PairDto>>(result);
            if (!ModelState.IsValid) return BadRequest(ModelState);
            return list;
        }

        public ActionResult<PairDto> GetRecord(Guid id)
        {
            var record = _repository.GetAsync(id).Result;
            if (record == null) return NotFound();
            PairDto dto = _mapper.Map<PairDto>(record);
            if (!ModelState.IsValid) return BadRequest(ModelState);
            return dto;
        }

        public IActionResult PostRecord(PairDto dto)
        {
            Pair record = _mapper.Map<Pair>(dto);
            bool result = _repository.PostData(record).Result;
            if (!result) return BadRequest();
            return Ok();
        }

        public IActionResult PutRecord(Guid id, PairDto dto)
        {
            Pair record = _mapper.Map<Pair>(dto);
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
