using AutoMapper;
using StudentProgress.BusinessLogic.Profiles.Dtos;
using StudentProgress.BusinessLogic.Requests;
using StudentProgress.DataAccess.Entities;

namespace StudentProgress.BusinessLogic.Profiles.MappingConfigurations;

public class SpecialtyProfile : Profile
{
    public SpecialtyProfile()
    {
        CreateMap<SpecialtyRequest, Specialty>()
            .ForMember(dest => dest.Name, opt => 
                opt.MapFrom(src => src.SpecialtyName));

        CreateMap<Specialty, SpecialtyDto>()
            .ForMember(dest => dest.SpecialtyName, opt =>
                opt.MapFrom(src => src.Name))
            .ReverseMap();
    }
}
