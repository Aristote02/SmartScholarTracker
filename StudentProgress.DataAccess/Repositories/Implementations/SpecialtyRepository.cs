using Microsoft.EntityFrameworkCore;
using StudentProgress.DataAccess.Data;
using StudentProgress.DataAccess.Entities;
using StudentProgress.DataAccess.Repositories.Interfaces;

namespace StudentProgress.DataAccess.Repositories.Implementations;

/// <summary>
/// impemented Specialty repository class
/// </summary>
public class SpecialtyRepository : ISpecialtyRepository
{
    /// <summary>
    /// injected application DbContext object
    /// </summary>
    private readonly ApplicationDbContext _context;
    public SpecialtyRepository(ApplicationDbContext context)
    {
        _context = context;   
    }

    /// <summary>
    /// Method to add specialty
    /// </summary>
    /// <param name="specialty"></param>
    /// <returns>specialty</returns>
    public async Task<Specialty> AddSpecialtyAsync(Specialty specialty)
    {
        _context.Specialties.Add(specialty);
        await _context.SaveChangesAsync();

        return specialty;

    }

    /// <summary>
    /// Method to delete specialty
    /// </summary>
    /// <param name="specialty"></param>
    /// <returns>specialty</returns>
    public async Task<Specialty> DeleteSpecialtyAsync(Specialty specialty)
    {
        _context.Specialties.Remove(specialty);
        await _context.SaveChangesAsync();

        return specialty;
    }

    /// <summary>
    /// Method to get all specialties
    /// </summary>
    /// <returns>list of specialties</returns>
    public async Task<List<Specialty>> GetAllSpecialtiesAsync()
    {
        return await _context.Specialties.AsNoTracking().ToListAsync();
    }

    /// <summary>
    /// Method to get specialty by id
    /// </summary>
    /// <param name="id"></param>
    /// <returns>specialty</returns>
    public async Task<Specialty?> GetSpecialtyByIdAsync(int id)
    {
        return await _context.Specialties.AsNoTracking().FirstOrDefaultAsync(s => s.Id == id);
    }

    /// <summary>
    /// Method to update specialty
    /// </summary>
    /// <param name="specialty"></param>
    /// <returns>specialty</returns>
    public async Task<Specialty> UpdateSpecialtyAsync(Specialty specialty)
    {
        _context.Specialties.Update(specialty);
        await _context.SaveChangesAsync();

        return specialty;
    }
}
