using StudentProgress.BusinessLogic.Profiles.Dtos;
using StudentProgress.BusinessLogic.Requests;

namespace StudentProgress.BusinessLogic.Services.Interfaces;

public interface ISpecialtyService
{
    Task<List<SpecialtyDto>> GetAllSpecialtiesAsync();
    Task<SpecialtyDto> GetSpecialtyByIdAsync(int id);
    Task<SpecialtyDto> AddSpecialtyAsync(SpecialtyRequest specialtyRequest);
    Task<SpecialtyDto> UpdateSpecialtyAsync(SpecialtyRequest specialtyRequest);
    Task<SpecialtyDto> DeleteSpecialty(int id);
}
