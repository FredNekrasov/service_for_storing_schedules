using API_for_mobile_app.Controllers;
using API_for_mobile_app.model.dto;
using API_for_mobile_app.model.entities;
using API_for_mobile_app.model.mappers;
using Microsoft.AspNetCore.Mvc;
using Web_API_for_scheduling.Models.repositories;

namespace Web_API_for_scheduling.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PairsController(IRepository<Pair> repository, IMapSpecialEntities<PairDto, Pair> mapper) : ControllerBase, IController
{
    private readonly IRepository<Pair> _repository = repository;
    private readonly IMapSpecialEntities<PairDto, Pair> _mapper = mapper;
    [HttpGet]
    public ActionResult GetList()
    {
        List<PairDto> list = [];
        var result = _repository.GetList();
        if (result == null) return NoContent();
        foreach (var item in result)
        {
            list.Add(_mapper.ToDTO(item)!);
        }
        return Ok(list);
    }
}
