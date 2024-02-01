﻿using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Web_API_for_scheduling.Models.dto;
using Web_API_for_scheduling.Models.entities;
using Web_API_for_scheduling.Models.repositories;

namespace Web_API_for_scheduling.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TeachersController(IRepository<Teacher> repository, IMapper mapper) : ControllerBase, IController<TeacherDto>
{
    private readonly IRepository<Teacher> _repository = repository;
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
    public async Task<ActionResult<IEnumerable<TeacherDto>>> GetListAsync()
    {
        var result = await _repository.GetListAsync();
        if (result == null) return NoContent();
        List<TeacherDto> list = _mapper.Map<List<TeacherDto>>(result);
        return Ok(list);
    }
    [HttpGet("{id}")]
    public async Task<ActionResult<TeacherDto>> GetRecordAsync(Guid id)
    {
        var record = await _repository.GetAsync(id);
        if (record == null) return NotFound();
        TeacherDto dto = _mapper.Map<TeacherDto>(record);
        return Ok(dto);
    }
    [HttpPost]
    public async Task<IActionResult> PostRecordAsync(TeacherDto dto)
    {
        Teacher record = _mapper.Map<Teacher>(dto);
        await _repository.PostData(record);
        return Ok();
    }
    [HttpPut("{id}")]
    public async Task<IActionResult> PutRecordAsync(Guid id, TeacherDto dto)
    {
        Teacher record = _mapper.Map<Teacher>(dto);
        bool? result = await _repository.PutData(id, record);
        return result switch
        {
            false => BadRequest(),
            null => NotFound(),
            true => NoContent(),
        };
    }
}
