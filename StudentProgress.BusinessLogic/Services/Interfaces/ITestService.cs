using StudentProgress.BusinessLogic.Profiles.Dtos;
using StudentProgress.BusinessLogic.Requests;

namespace StudentProgress.BusinessLogic.Services.Interfaces;

public interface ITestService
{
    Task<List<TestDto>> GetAllTestsAsync();
    Task<TestDto?> GetTestByIdAsync(int id);
    Task<TestDto> AddTestAsync(TestRequest testRequest);
    Task<TestDto> UpdateTestAsync(TestRequest testRequest);
    Task<TestDto> DeleteTestAsync(int id);
}
