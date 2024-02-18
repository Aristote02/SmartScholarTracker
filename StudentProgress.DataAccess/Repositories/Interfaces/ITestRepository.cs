using StudentProgress.DataAccess.Entities;

namespace StudentProgress.DataAccess.Repositories.Interfaces;

public interface ITestRepository
{
    Task<List<Test>> GetAllTestAsync();
    Task<Test?> GetTestByIdAsync(int id);
    Task<Test> AddTestAsync(Test test);
    Task<Test> UpdateTestAsync(Test test);
    Task<Test> DeleteTestAsync(Test test);
}
