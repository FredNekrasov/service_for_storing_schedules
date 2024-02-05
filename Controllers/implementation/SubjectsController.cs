using API_for_mobile_app.Controllers;
using API_for_mobile_app.model.dto;
using API_for_mobile_app.model.entities;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Web_API_for_scheduling.Models.repositories;

namespace Web_API_for_scheduling.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SubjectsController(IRepository<Subject> repository, IMapper mapper) : ControllerBase, IController
{
    private readonly IRepository<Subject> _repository = repository;
    private readonly IMapper _mapper = mapper;
    [HttpGet]
    public ActionResult GetList()
    {
        var result = _repository.GetList();
        if (result == null) return NoContent();
        List<SubjectDto> list = _mapper.Map<List<SubjectDto>>(result);
        return Ok(list);
    }
}
