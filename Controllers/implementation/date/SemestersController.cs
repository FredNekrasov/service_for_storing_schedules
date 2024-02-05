using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Web_API_for_scheduling.Models.repositories;
using API_for_mobile_app.model.entities.date;
using API_for_mobile_app.model.dto.date;
using API_for_mobile_app.Controllers;

namespace Web_API_for_scheduling.Controllers.date;

[Route("api/[controller]")]
[ApiController]
public class SemestersController(IRepository<Semester> repository, IMapper mapper) : ControllerBase, IController
{
    private readonly IRepository<Semester> _repository = repository;
    private readonly IMapper _mapper = mapper;
    [HttpGet]
    public ActionResult GetList()
    {
        var result = _repository.GetList();
        if (result == null) return NoContent();
        List<SemesterDto> list = _mapper.Map<List<SemesterDto>>(result);
        return Ok(list);
    }
}
