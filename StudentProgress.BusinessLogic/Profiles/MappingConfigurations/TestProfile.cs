using AutoMapper;
using StudentProgress.BusinessLogic.Profiles.Dtos;
using StudentProgress.BusinessLogic.Requests;
using StudentProgress.DataAccess.Entities;

namespace StudentProgress.BusinessLogic.Profiles.MappingConfigurations;

public class TestProfile : Profile
{
    public TestProfile()
    {
        CreateMap<TestRequest, Test>();
            
        CreateMap<Test, TestDto>()
            .ForMember(dest => dest.SubjectName, opt => 
                opt.MapFrom(src => src.Subject.Name))

            .ForMember(dest => dest.TypeOfTest, opt =>
                opt.MapFrom(src => src.TypeOfTest))
            .ReverseMap();
    }
}
