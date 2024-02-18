using AutoMapper;
using StudentProgress.BusinessLogic.Profiles.Dtos;
using StudentProgress.BusinessLogic.Requests;
using StudentProgress.DataAccess.Entities;

namespace StudentProgress.BusinessLogic.Profiles.MappingConfigurations;

public class AppUserProfile : Profile
{
	public AppUserProfile()
	{
        CreateMap<AppUserRequest, AppUser>()
            .ForMember(dest => dest.UserName, options => options.MapFrom(source => source.Name));
        CreateMap<AppUser, AppUserDto>()
            .ReverseMap();
    }
}
