using StudentProgress.BusinessLogic.Profiles.Dtos;
using StudentProgress.BusinessLogic.Requests;

namespace StudentProgress.BusinessLogic.Services.Interfaces;

public interface IStudentService
{
    Task<List<StudentDto>> GetAllStudentsAsync();
    Task<StudentDto?> GetStudentByIdAsync(int id);
    Task<int> GetStudentIdByNameAsync(string studentName);
    Task<StudentDto> AddStudentAsync(StudentRequest studentRequest);
    Task<StudentDto> UpdateStudentAsync(StudentRequest studentRequest);
    Task<StudentDto> DeleteStudentAsync(int id);
}
