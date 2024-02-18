using AutoMapper;
using StudentProgress.BusinessLogic.Profiles.Dtos;
using StudentProgress.BusinessLogic.Requests;
using StudentProgress.DataAccess.Entities;

namespace StudentProgress.BusinessLogic.Profiles.MappingConfigurations;

public class SubjectProfile : Profile
{
    public SubjectProfile()
    {
        CreateMap<SubjectRequest, Subject>()
            .ForMember(dest => dest.Name, opt =>
            opt.MapFrom(src => src.SubjectName));

        CreateMap<Subject, SubjectDto>()
            .ForMember(dest => dest.SubjectName, opt => 
                opt.MapFrom(src => src.Name))
            .ReverseMap();
    }
}
