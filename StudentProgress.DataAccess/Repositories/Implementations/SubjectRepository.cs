using Microsoft.EntityFrameworkCore;
using StudentProgress.DataAccess.Data;
using StudentProgress.DataAccess.Entities;
using StudentProgress.DataAccess.Repositories.Interfaces;

namespace StudentProgress.DataAccess.Repositories.Implementations;

/// <summary>
/// Implemented Subject repository
/// </summary>
public class SubjectRepository : ISubjectRepository
{
    /// <summary>
    /// injected application Dbcontext object
    /// </summary>
    private readonly ApplicationDbContext _context;

    public SubjectRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Method to add new subject
    /// </summary>
    /// <param name="subject"></param>
    /// <returns>subject</returns>
    public async Task<Subject> AddSubjectAsync(Subject subject)
    {
        _context.Subjects.Add(subject);
        await _context.SaveChangesAsync();

        return subject;
    }

    /// <summary>
    /// method to delete subject
    /// </summary>
    /// <param name="subject"></param>
    /// <returns>subject</returns>
    public async Task<Subject> DeleteSubjectAsync(Subject subject)
    {
        _context.Subjects.Remove(subject);
        await _context.SaveChangesAsync();

        return subject;
    }

    /// <summary>
    /// Method to get all the subjects
    /// </summary>
    /// <returns>list of subjects</returns>
    public async Task<List<Subject>> GetAllSubjectsAsync()
    {
        return await _context.Subjects.AsNoTracking().ToListAsync();
    }

    /// <summary>
    /// Method to get subject by Id
    /// </summary>
    /// <param name="id"></param>
    /// <returns>subject</returns>
    public async Task<Subject?> GetSubjectByIdAsync(int id)
    {
        return await _context.Subjects.AsNoTracking().FirstOrDefaultAsync(s =>  s.Id == id);
    }

    /// <summary>
    /// Method to update subject
    /// </summary>
    /// <param name="subject"></param>
    /// <returns>subject</returns>
    public async Task<Subject> UpdateSubjectAsync(Subject subject)
    {
        _context.Subjects.Update(subject);
        await _context.SaveChangesAsync();

        return subject;
    }
}
