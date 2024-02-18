using StudentProgress.DataAccess.Entities;

namespace StudentProgress.DataAccess.Repositories.Interfaces;

public interface ISpecialtyRepository
{
    Task<List<Specialty>> GetAllSpecialtiesAsync();
    Task<Specialty?> GetSpecialtyByIdAsync(int  id);
    Task<Specialty> AddSpecialtyAsync(Specialty specialty); 
    Task<Specialty> UpdateSpecialtyAsync(Specialty specialty);
    Task<Specialty> DeleteSpecialtyAsync(Specialty specialty);
}
