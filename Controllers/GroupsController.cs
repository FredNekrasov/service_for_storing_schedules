﻿using AutoMapper;
using Humanizer;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
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
        public IActionResult DeleteRecord(Guid id)
        {
            bool result = _repository.DeleteAsync(id).Result;
            if (!result) return NotFound();
            return Ok();
        }

        public ActionResult<IEnumerable<GroupDto>> GetList()
        {
            var result = _repository.GetListAsync().Result;
            if (result == null) return NoContent();
            List<GroupDto> list = _mapper.Map<List<GroupDto>>(result);
            if (!ModelState.IsValid) return BadRequest(ModelState);
            return list;
        }

        public ActionResult<GroupDto> GetRecord(Guid id)
        {
            var record = _repository.GetAsync(id).Result;
            if (record == null) return NotFound();
            GroupDto dto = _mapper.Map<GroupDto>(record);
            if (!ModelState.IsValid) return BadRequest(ModelState);
            return dto;
        }

        public IActionResult PostRecord(GroupDto dto)
        {
            Group record = _mapper.Map<Group>(dto);
            bool result = _repository.PostData(record).Result;
            if (!result) return BadRequest();
            return Ok();
        }

        public IActionResult PutRecord(Guid id, GroupDto dto)
        {
            Group record = _mapper.Map<Group>(dto);
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
