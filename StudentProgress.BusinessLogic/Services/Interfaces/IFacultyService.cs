using StudentProgress.BusinessLogic.Profiles.Dtos;
using StudentProgress.BusinessLogic.Requests;

namespace StudentProgress.BusinessLogic.Services.Interfaces
{
    public interface IFacultyService
    {
        Task<List<FacultyDto>> GetAllFacultiesAsync();
        Task<FacultyDto> GetFacultyByIdAsync(int id);
        Task<FacultyDto> AddFacultyAsync(FacultyRequest facultyRequest);
        Task<FacultyDto> UpdateFacultyAsync(FacultyRequest facultyRequest);
        Task<FacultyDto> DeleteFacultyAsync(int id);
    }
}
