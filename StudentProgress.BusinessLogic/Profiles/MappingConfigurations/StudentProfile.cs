using AutoMapper;
using StudentProgress.BusinessLogic.Profiles.Dtos;
using StudentProgress.BusinessLogic.Requests;
using StudentProgress.DataAccess.Entities;

namespace StudentProgress.BusinessLogic.Profiles.MappingConfigurations;

public class StudentProfile : Profile
{
	public StudentProfile()
	{
		CreateMap<StudentRequest, Student>()
			.ForMember(dest => dest.FirstName, opt =>
				opt.MapFrom(src => src.FullName));

			
		CreateMap<Student, StudentDto>()
			.ForMember(dest => dest.Faculty, opt => 
				opt.MapFrom(src => src.Faculty.Name))

			.ForMember(dest => dest.Specialty, opt =>
				opt.MapFrom(src => src.Specialty.Name))

			.ForMember(dest => dest.GroupName, opt =>
				opt.MapFrom(src => src.Group))
            .ReverseMap();
	}
}
