using API_for_mobile_app.model.dto;
using API_for_mobile_app.model.entities;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Web_API_for_scheduling.Models.repositories;

namespace API_for_mobile_app.Controllers.implementation
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeacherController(IRepository<Teacher> repository, IMapper mapper) : ControllerBase, IController
    {
        private readonly IRepository<Teacher> _repository = repository;
        private readonly IMapper _mapper = mapper;
        [HttpGet]
        public ActionResult GetList()
        {
            var result = _repository.GetList();
            if (result == null) return NoContent();
            List<TeacherDto> list = _mapper.Map<List<TeacherDto>>(result);
            return Ok(list);
        }
    }
}
