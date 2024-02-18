using AutoMapper;
using StudentProgress.BusinessLogic.Profiles.Dtos;
using StudentProgress.BusinessLogic.Requests;
using StudentProgress.DataAccess.Entities;

namespace StudentProgress.BusinessLogic.Profiles.MappingConfigurations;

/// <summary>
// As you can understand ExamProfile class is a configuration class for AutoMapper. 
//It tells AutoMapper how to map properties from one type to another.
//In this specific case, it instructs AutoMapper to map properties like
//StudentName and TestName in the ExamDto
/// </summary>
public class ExamProfile : Profile
{
	/// <summary>
	/// 
	/// </summary>
	public ExamProfile()
	{
		//Configures AutoMapper to map from ExamRequest to Exam
		//and vice versa. It's a bidirectional mapping configuration
		//That's why i used ReverseMap
		CreateMap<ExamRequest, Exam>()
			.ReverseMap();

		//This configuration maps properties StudentName and TestName
		//in the ExamDto class from the properties (Student.FirstName and Test.TypeOfTest)
		//in the Exam class bidirectionally.
		CreateMap<Exam, ExamDto>()
			.ForMember(dest => dest.StudentName, opt =>
				opt.MapFrom(src => src.Student.FirstName))
			.ForMember(dest => dest.TestName, opt =>
				opt.MapFrom(src => src.Test.TypeOfTest))
			.ReverseMap();
	}
}
