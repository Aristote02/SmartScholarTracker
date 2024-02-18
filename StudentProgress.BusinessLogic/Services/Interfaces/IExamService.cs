using StudentProgress.BusinessLogic.Models;
using StudentProgress.BusinessLogic.Profiles.Dtos;
using StudentProgress.BusinessLogic.Requests;
using StudentProgress.DataAccess.Models;

namespace StudentProgress.BusinessLogic.Services.Interfaces
{
    public interface IExamService
    {
        Task<List<ExamDto>> GetAllExamAsync();
        Task<ExamDto?> GetExamByIdAsync(int id);
        Task<ExamDto> AddExamAsync(ExamRequest examRequest);
        Task<ExamDto> UpdateExamAsync(ExamRequest examRequest);
        Task<ExamDto> DeleteExamAsync(int id);
        Task<ExamDto?> FindExamByTestTypeAsync(string testType);
        Task<List<StudentAveragePoint>> GetAveragePointAsync();
        Task<List<MostDifficultAndSimplestSubject>> DifficultSubjectPerSpecialtyAsync();
        Task<List<MostDifficultAndSimplestSubject>> SimplestSubjectPerSpecialtyAsync();
        Task<List<LaggingBehindStudent>> LaggingBehindStudentAsync(DateTime startDate, DateTime endDate);
        Task<List<MostSuccessfulStudent>> MostSuccessfulStudentsAsync(DateTime startDate, DateTime endDate);

    }
}
