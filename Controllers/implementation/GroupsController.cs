using API_for_mobile_app.Controllers;
using API_for_mobile_app.model.dto;
using API_for_mobile_app.model.entities;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Web_API_for_scheduling.Models.repositories;

namespace Web_API_for_scheduling.Controllers;

[Route("api/[controller]")]
[ApiController]
public class GroupsController(IRepository<Group> repository, IMapper mapper) : ControllerBase, IController
{
    private readonly IRepository<Group> _repository = repository;
    private readonly IMapper _mapper = mapper;
    [HttpGet]
    public ActionResult GetList()
    {
        var result = _repository.GetList();
        if (result == null) return NoContent();
        List<GroupDto> list = _mapper.Map<List<GroupDto>>(result);
        return Ok(list);
    }
}
