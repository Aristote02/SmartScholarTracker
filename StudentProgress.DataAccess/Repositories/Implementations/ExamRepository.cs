   #region
using Microsoft.EntityFrameworkCore;
using StudentProgress.BusinessLogic.Models;
using StudentProgress.DataAccess.Data;
using StudentProgress.DataAccess.Entities;
using StudentProgress.DataAccess.Models;
using StudentProgress.DataAccess.Repositories.Interfaces;
#endregion

namespace StudentProgress.DataAccess.Repositories.Implementations;

/// <summary>
/// Implementing the exam repository  
/// </summary>
public class ExamRepository : IExamRepository
{
    /// <summary>
    /// Application DbContext object
    /// </summary>
    private readonly ApplicationDbContext _context;
    public ExamRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Method to add exam
    /// </summary>
    /// <param name="exam"></param>
    /// <returns>exam</returns>
    public async Task<Exam> AddExamAsync(Exam exam)
    {
        _context.Exams.Add(exam);
        await _context.SaveChangesAsync();

        return exam;
    }

    /// <summary>
    /// Method to delete exam
    /// </summary>
    /// <param name="exam"></param>
    /// <returns>exam</returns>
    public async Task<Exam> DeleteExamAsync(Exam exam)
    {
        _context.Exams.Remove(exam);
        await _context.SaveChangesAsync();

        return exam;
    }

    /// <summary>
    /// Method to get all the exams
    /// </summary>
    /// <returns>list of exams</returns>
    public async Task<List<Exam>> GetAllExamAsync()
    {
        return await _context.Exams
            .Include(s => s.Student)
            .Include(t => t.Test)
            .AsNoTracking()
            .ToListAsync();
    }

    /// <summary>
    /// Method to get exam by id
    /// </summary>
    /// <param name="id"></param>
    /// <returns>exam</returns>
    public async Task<Exam?> GetExamByIdAsync(int id)
    {
        return await _context.Exams
            .Include(s => s.Student)
            .AsNoTracking()
            .FirstOrDefaultAsync(e => e.Id == id);
    }

    /// <summary>
    /// method to update exam
    /// </summary>
    /// <param name="exam"></param>
    /// <returns></returns>
    public async Task<Exam> UpdateExamAsync(Exam exam)
    {
        _context.Exams.Update(exam);
        await _context.SaveChangesAsync();

        return exam;
    }

    /// <summary>
    /// This method to calculate the Average score of each student 
    /// grouped by faculties, courses, specialties
    /// </summary>
    /// <returns>A list of Student's Average Point</returns>
    public async Task<List<StudentAveragePoint>> GetAveragePointAsync()
    {
        var studentAverages = await _context.Exams
            .Include(e => e.Student)
            .ThenInclude(s => s.Specialty)
            .Include(f => f.Student)
            .ThenInclude(f => f.Faculty)
            .GroupBy(e => new
            {
                //StudentName = e.Student.FirstName,
                Specialty = e.Student.Specialty.Name,
                Faculty = e.Student.Faculty.Name
            })
            .Select(s => new StudentAveragePoint
            {
                //StudentName = s.Key.StudentName,
                Specialty = s.Key.Specialty,
                Faculty = s.Key.Faculty,
                AveragePoint = s.Average(e => e.Point)
            }).ToListAsync();

        return studentAverages;
    }

    /// <summary>
    /// Find the most difficult subject for each Specialty
    /// </summary>
    /// <returns>List of MostDifficultSubject</returns>
    public async Task<List<MostDifficultAndSimplestSubject>> DifficultSubjectPerSpecialtyAsync()
    {
        var resultDifficultSubject = await _context.Exams
            .Include(s => s.Student.Specialty)
            .Include(sub => sub.Test.Subject)
            .GroupBy(s => new
            {
                Specialty = s.Student.Specialty.Name,
                Subject = s.Test.Subject.Name
            })
            .Select(group => new
            {
                SpecialtyName = group.Key.Specialty,
                SubjecName = group.Key.Subject,
                AveragePoint = group.Average(s => s.Point)
            })
            .GroupBy(i => i.SpecialtyName)
            .Select(group => new MostDifficultAndSimplestSubject
            {
                Specialty = group.Key,
                Subject = group.OrderBy(x => x.AveragePoint).First().SubjecName,
                AverageSubjectPoint = group.Min(x => x.AveragePoint)
            }).ToListAsync();

        return resultDifficultSubject;
    }

    /// <summary>
    /// Find the simplest subject for each specialty
    /// </summary>
    /// <returns>List of MostDifficultSubject</returns>
    public async Task<List<MostDifficultAndSimplestSubject>> SimplestSubjectPerSpecialtyAsync()
    {
        var resultSimplestSubject = await _context.Exams
            .Include(s => s.Student.Specialty)
            .Include(sb => sb.Test.Subject)
            .GroupBy(x => new
            {
                Specialty = x.Student.Specialty.Name,
                Subject = x.Test.Subject.Name
            })
            .Select(group => new
            {
                SpecialtyName = group.Key.Specialty,
                SubjectName = group.Key.Subject,
                AveragePoint = group.Average(s => s.Point)
            })
            .GroupBy(i => i.SpecialtyName)
            .Select(group => new MostDifficultAndSimplestSubject
            {
                Specialty = group.Key,
                Subject = group.OrderBy(x => x.AveragePoint).First().SubjectName,
                AverageSubjectPoint = group.Max(x => x.AveragePoint)
            }).ToListAsync();


        return resultSimplestSubject;
    }

    /// <summary>
    /// This method find the most successful student
    /// in each specialty
    /// </summary>
    /// <param name="startDate"></param>
    /// <param name="endDate"></param>
    /// <returns>mostSuccessfulStudent</returns>
    public async Task<List<MostSuccessfulStudent>> MostSuccessfulStudentsAsync(DateTime startDate, DateTime endDate)
    {
        var mostSuccessfulStudent = await _context.Exams
            .Include(e => e.Student)
                .ThenInclude(s => s.Specialty)
            .Include(t => t.Test)
            .Where(e => e.Test.DateTime >= startDate && e.Test.DateTime <= endDate)
            .GroupBy(x => new
            {
                SpecialtyName = x.Student.Specialty.Name
            })
            .Select(g => new MostSuccessfulStudent
            {
                Specialty = g.Key.SpecialtyName,
                StudentName = g.OrderByDescending(x => x.Point).Select(x => x.Student.FirstName).FirstOrDefault(),
                Point = g.Max(x => x.Point)
            }).ToListAsync();


        return mostSuccessfulStudent;
    }

    /// <summary>
    /// Methods to find the lagging behind student
    /// in each specialty
    /// </summary>
    /// <param name="startDate"></param>
    /// <param name="endDate"></param>
    /// <returns>laggingBehindStudents</returns>
    public async Task<List<LaggingBehindStudent>> LaggingBehindStudentAsync(DateTime startDate, DateTime endDate)
    {
        var laggingBehindStudents = await _context.Exams
            .Include(e => e.Student)
                .ThenInclude(sp => sp.Specialty)
            .Include(t => t.Test)
            .Where(e => e.Test.DateTime >= startDate && e.Test.DateTime <= endDate)
            .GroupBy(x => new
            {
                SpecialtyName = x.Student.Specialty.Name
            })
            .Select(g => new LaggingBehindStudent
            {
                Specialty = g.Key.SpecialtyName,
                StudentName = g.OrderBy(x => x.Point).Select(x => x.Student.FirstName).FirstOrDefault(),
                Point = g.Min(x => x.Point)
            }).ToListAsync();

        return laggingBehindStudents;
    }

    /// <summary>
    /// method to find the student's name
    /// </summary>
    /// <param name="studentName"></param>
    /// <returns>exam</returns>
    public async Task<Exam?> GetExamByStudentNameAsync(string studentName)
    {
        var exam = await _context.Exams
            .FirstOrDefaultAsync(s => s.Student != null && s.Student.FirstName.Equals(studentName));

        return exam;
    }


    /// <summary>
    /// method to find exam by type of test+
    /// </summary>
    /// <param name="testType"></param>
    /// <returns>exam</returns>
    public async Task<Exam?> FindExamByTestTypeAsync(string testType)
    {
        var exam = await _context.Exams.FirstOrDefaultAsync(s => s.Test != null && s.Test.TypeOfTest.Equals(testType));

        return exam;
    }

    public async Task<Exam?> GetStudentNameByExamIdAsync(int id)
    {
        var exam = await _context.Exams
            .Where(e => e.Id == id)
            .Include(e => e.Student)
            .FirstOrDefaultAsync();

        return exam;
    }
}
