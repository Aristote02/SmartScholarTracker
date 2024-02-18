using StudentProgress.DataAccess.Entities;

namespace StudentProgress.DataAccess.Repositories.Interfaces;

public interface IFacultyRepository
{
    Task<List<Faculty>> GetAllFacultiesAsync();
    Task<Faculty?> GetFacultyByIdAsync(int id);
    Task<Faculty> AddFacultyAsync(Faculty faculty);
    Task<Faculty> UpdateFacultyAsync(Faculty faculty);
    Task<Faculty> DeleteFacultyAsync(Faculty faculty);
}
