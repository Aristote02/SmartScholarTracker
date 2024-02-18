using StudentProgress.DataAccess.Entities;

namespace StudentProgress.DataAccess.Repositories.Interfaces;

public interface ISubjectRepository
{
    Task<List<Subject>> GetAllSubjectsAsync();
    Task<Subject?> GetSubjectByIdAsync(int id);
    Task<Subject> AddSubjectAsync(Subject subject);
    Task<Subject> UpdateSubjectAsync(Subject subject);
    Task<Subject> DeleteSubjectAsync(Subject subject);
}
