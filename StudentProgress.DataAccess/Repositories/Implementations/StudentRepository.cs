using Microsoft.EntityFrameworkCore;
using StudentProgress.DataAccess.Data;
using StudentProgress.DataAccess.Entities;
using StudentProgress.DataAccess.Repositories.Interfaces;

namespace StudentProgress.DataAccess.Repositories.Implementations;

/// <summary>
/// Implemented Student Repository class
/// </summary>
public class StudentRepository : IStudentRepository
{
    /// <summary>
    /// injected application DbContext object
    /// </summary>
    private readonly ApplicationDbContext _context; 
    public StudentRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Method to add student 
    /// </summary>
    /// <param name="student"></param>
    /// <returns>student</returns>
    public async Task<Student> AddStudentAsync(Student student)
    {
        _context.Students.Add(student);
        await _context.SaveChangesAsync();

        return student;
    }

    /// <summary>
    /// Method to delete a student
    /// </summary>
    /// <param name="student"></param>
    /// <returns>student</returns>
    public async Task<Student> DeleteStudentAsync(Student student)
    {
        _context.Students.Remove(student);
        await _context.SaveChangesAsync();

        return student;
    }

    /// <summary>
    /// Method to get all student
    /// </summary>
    /// <returns>list of students</returns>
    public async Task<List<Student>> GetAllStudentsAsync()
    {
        return await _context.Students
            .Include(f => f.Faculty)
            .Include(s => s.Specialty)
            .AsNoTracking()
            .ToListAsync();
    }

    /// <summary>
    /// Method to get student by id
    /// </summary>
    /// <param name="id"></param>
    /// <returns>student</returns>
    public Task<Student?> GetStudentByIdAsync(int id)
    {
        return _context.Students.AsNoTracking().FirstOrDefaultAsync(s => s.Id == id);
    }

    public async Task<Student?> GetStudentByName(string name)
    {
        return await _context.Students.FirstOrDefaultAsync(s => s.FirstName == name);
    }

    /// <summary>
    /// Method to update student 
    /// </summary>
    /// <param name="student"></param>
    /// <returns>student</returns>
    public async Task<Student> UpdateStudentAsync(Student student)
    {
        _context.Students.Update(student);
        await _context.SaveChangesAsync();

        return student;
    }
}
