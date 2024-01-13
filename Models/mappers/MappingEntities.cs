using AutoMapper;
using Web_API_for_scheduling.Models.dto;
using Web_API_for_scheduling.Models.dto.date;
using Web_API_for_scheduling.Models.dto.rooms;
using Web_API_for_scheduling.Models.entities;
using Web_API_for_scheduling.Models.entities.date;
using Web_API_for_scheduling.Models.entities.rooms;

namespace Web_API_for_scheduling.Models.mappers
{
    public class MappingEntities : Profile
    {
        public MappingEntities()
        {
            CreateMap<Semester, SemesterDto>();
            CreateMap<Week, WeekDto>();
            CreateMap<AudienceType, AudienceTypeDto>();
            CreateMap<Group, GroupDto>();
            CreateMap<Subject, SubjectDto>();
            CreateMap<Teacher, TeacherDto>();
            CreateMap<Pair, PairDto>();
            CreateMap<Day, DayDto>();

            CreateMap<SemesterDto, Semester>();
            CreateMap<AudienceTypeDto, AudienceType>();
            CreateMap<GroupDto, Group>();
            CreateMap<SubjectDto, Subject>();
            CreateMap<TeacherDto, Teacher>();
        }
    }
}
