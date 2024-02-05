using API_for_mobile_app.Controllers;
using API_for_mobile_app.model.dto.rooms;
using API_for_mobile_app.model.entities.rooms;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Web_API_for_scheduling.Models.repositories;

namespace Web_API_for_scheduling.Controllers.rooms;

[Route("api/[controller]")]
[ApiController]
public class AudienceTypesController(IRepository<AudienceType> repository, IMapper mapper) : ControllerBase, IController
{
    private readonly IRepository<AudienceType> _repository = repository;
    private readonly IMapper _mapper = mapper;
    [HttpGet]
    public ActionResult GetList()
    {
        var result = _repository.GetList();
        if (result == null) return NoContent();
        List<AudienceTypeDto> list = _mapper.Map<List<AudienceTypeDto>>(result);
        return Ok(list);
    }
}
