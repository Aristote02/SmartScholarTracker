using StudentProgress.BusinessLogic.Profiles.Dtos;
using StudentProgress.BusinessLogic.Requests;

namespace StudentProgress.BusinessLogic.Services.Interfaces
{
    public interface ISubjectService
    {
        Task<List<SubjectDto>> GetAllSubjectsAsync();
        Task<SubjectDto> GetSubjectByIdAsync(int id);
        Task<SubjectDto> AddSubjectAsync(SubjectRequest subjectRequest);
        Task<SubjectDto> UpdateSubjectAsync(SubjectRequest subjectRequest);
        Task<SubjectDto> DeleteSubjectAsync(int id);
    }
}
