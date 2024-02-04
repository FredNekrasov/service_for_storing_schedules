using API_for_mobile_app.model.dto;
using API_for_mobile_app.model.dto.date;
using API_for_mobile_app.model.dto.rooms;
using API_for_mobile_app.model.entities;
using API_for_mobile_app.model.entities.date;
using API_for_mobile_app.model.entities.rooms;
using AutoMapper;

namespace API_for_mobile_app.model.mappers
{
    public class MappingSimpleEntities : Profile
    {
        public MappingSimpleEntities()
        {
            CreateMap<Semester, SemesterDto>();
            CreateMap<AudienceType, AudienceTypeDto>();
            CreateMap<Group, GroupDto>();
            CreateMap<Subject, SubjectDto>();
            CreateMap<Teacher, TeacherDto>();
        }
    }
}
