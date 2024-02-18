using AutoMapper;
using StudentProgress.BusinessLogic.Profiles.Dtos;
using StudentProgress.BusinessLogic.Requests;
using StudentProgress.DataAccess.Entities;

namespace StudentProgress.BusinessLogic.Profiles.MappingConfigurations;

public class FacultyProfile : Profile
{
	public FacultyProfile()
	{
		CreateMap<FacultyRequest, Faculty>()
			.ForMember(dest => dest.Name, opt =>
				opt.MapFrom(src => src.FacultyName));

		CreateMap<Faculty, FacultyDto>()
            .ForMember(dest => dest.FacultyName, opt =>
                opt.MapFrom(src => src.Name))
            .ReverseMap();
	}
}
