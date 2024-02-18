using StudentProgress.BusinessLogic.Models;
using StudentProgress.DataAccess.Entities;
using StudentProgress.DataAccess.Models;

namespace StudentProgress.DataAccess.Repositories.Interfaces;

public interface IExamRepository
{
    Task<List<Exam>> GetAllExamAsync();
    Task<Exam?> GetExamByIdAsync(int id);
    Task<Exam> AddExamAsync(Exam exam);
    Task<Exam> UpdateExamAsync(Exam exam);
    Task<Exam> DeleteExamAsync(Exam exam);
    Task<Exam?> GetExamByStudentNameAsync(string studentName);
    Task<Exam?> GetStudentNameByExamIdAsync(int id);
    Task<Exam?> FindExamByTestTypeAsync(string testType);
    Task<List<StudentAveragePoint>> GetAveragePointAsync();
    Task<List<MostDifficultAndSimplestSubject>> DifficultSubjectPerSpecialtyAsync();
    Task<List<MostDifficultAndSimplestSubject>> SimplestSubjectPerSpecialtyAsync();
    Task<List<LaggingBehindStudent>> LaggingBehindStudentAsync(DateTime startDate, DateTime endDate);
    Task<List<MostSuccessfulStudent>> MostSuccessfulStudentsAsync(DateTime startDate, DateTime endDate);

}
