#region
using AutoMapper;
using StudentProgress.BusinessLogic.Exceptions;
using StudentProgress.BusinessLogic.Profiles.Dtos;
using StudentProgress.BusinessLogic.Requests;
using StudentProgress.BusinessLogic.Services.Interfaces;
using StudentProgress.DataAccess.Entities;
using StudentProgress.DataAccess.Repositories.Interfaces;
#endregion

namespace StudentProgress.BusinessLogic.Services.Implementations;

public class TestService : ITestService
{
    private readonly ITestRepository _testRepository;
    private readonly IMapper _mapper;
    public TestService(ITestRepository testRepository, IMapper mapper)
    {
        _testRepository = testRepository;
        _mapper = mapper;
    }

    public async Task<TestDto> AddTestAsync(TestRequest testRequest)
    {
        var test = await _testRepository.AddTestAsync(_mapper.Map<Test>(testRequest));

        return _mapper.Map<TestDto>(test);
    }

    public async Task<TestDto> DeleteTestAsync(int id)
    {
        var test = await _testRepository.GetTestByIdAsync(id);

        if(test is null) { throw new NotFoundException("There is no any type of test with such an id"); }

        var deletedTest = await _testRepository.DeleteTestAsync(test);

        return _mapper.Map<TestDto>(deletedTest);
    }

    public async Task<List<TestDto>> GetAllTestsAsync()
    {
        var tests = await _testRepository.GetAllTestAsync();

        return _mapper.Map<List<TestDto>>(tests);
    }

    public async Task<TestDto?> GetTestByIdAsync(int id)
    {
        var test = await _testRepository.GetTestByIdAsync(id);

        if(test is null) { throw new NotFoundException("There is no any type of test with such an id"); }

        return _mapper.Map<TestDto>(test);
    }

    public async Task<TestDto> UpdateTestAsync(TestRequest testRequest)
    {
        var test = await _testRepository.GetTestByIdAsync(testRequest.Id);

        if(test is null) { throw new NotFoundException("There is no any type of test with such an id"); }

        _mapper.Map(testRequest, test);
        var updatedTest = await _testRepository.UpdateTestAsync(test);

        return _mapper.Map<TestDto>(updatedTest);
    }
}
