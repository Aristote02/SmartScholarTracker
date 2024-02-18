#region
using AutoMapper;
using StudentProgress.BusinessLogic.Exceptions;
using StudentProgress.BusinessLogic.Models;
using StudentProgress.BusinessLogic.Profiles.Dtos;
using StudentProgress.BusinessLogic.Requests;
using StudentProgress.BusinessLogic.Services.Interfaces;
using StudentProgress.DataAccess.Entities;
using StudentProgress.DataAccess.Models;
using StudentProgress.DataAccess.Repositories.Interfaces;
#endregion

namespace StudentProgress.BusinessLogic.Services.Implementations;

public class ExamService : IExamService
{
    private readonly IExamRepository _examRepository;
    //private readonly IStudentService _studentService;
    private readonly IMapper _mapper;
    public ExamService(IExamRepository examRepository, IMapper mapper/*, IStudentService studentService*/)
    {
        _examRepository = examRepository;
        _mapper = mapper;
        //_studentService = studentService;
    }
 
    public async Task<ExamDto> AddExamAsync(ExamRequest examRequest)
    {
        var exam = await _examRepository.AddExamAsync(_mapper.Map<Exam>(examRequest));

        return _mapper.Map<ExamDto>(exam);

    }

    public async Task<ExamDto> DeleteExamAsync(int id)
    {
        var exam = await _examRepository.GetExamByIdAsync(id);

        if (exam is null) { throw new NotFoundException("There is not any exam with such and id"); }

        var examDeleted = await _examRepository.DeleteExamAsync(exam);

        return _mapper.Map<ExamDto>(examDeleted);
    }

    public async Task<List<MostDifficultAndSimplestSubject>> DifficultSubjectPerSpecialtyAsync()
    {
        return await _examRepository.DifficultSubjectPerSpecialtyAsync();
    }

    public async Task<ExamDto?> FindExamByTestTypeAsync(string testType)
    {
        var examTestType = await _examRepository.FindExamByTestTypeAsync(testType);

        return _mapper.Map<ExamDto?>(examTestType);
    }

    public async Task<List<ExamDto>> GetAllExamAsync()
    {
        var exams = await _examRepository.GetAllExamAsync();

        return _mapper.Map<List<ExamDto>>(exams);
    }

    public async Task<List<StudentAveragePoint>> GetAveragePointAsync()
    {
        return await _examRepository.GetAveragePointAsync();
    }

    public async Task<ExamDto?> GetExamByIdAsync(int id)
    {
        var exam = await _examRepository.GetExamByIdAsync(id);

        if (exam is null) { throw new NotFoundException("There is not any exam with such an id"); }

        return _mapper.Map<ExamDto>(exam);
    }

    public async Task<List<LaggingBehindStudent>> LaggingBehindStudentAsync(DateTime startDate, DateTime endDate)
    {
        return await _examRepository.LaggingBehindStudentAsync(startDate, endDate);
    }

    public async Task<List<MostSuccessfulStudent>> MostSuccessfulStudentsAsync(DateTime startDate, DateTime endDate)
    {
        return await _examRepository.MostSuccessfulStudentsAsync(startDate, endDate);
    }

    public async Task<List<MostDifficultAndSimplestSubject>> SimplestSubjectPerSpecialtyAsync()
    {
        return await _examRepository.SimplestSubjectPerSpecialtyAsync();
    }

    public async Task<ExamDto> UpdateExamAsync(ExamRequest examRequest)
    {
        var exam = await _examRepository.GetExamByIdAsync(examRequest.Id);

        if (exam is null) { throw new NotFoundException("There is not any exam with such an Id"); }

        exam.Point = examRequest.Point;

        var updatedExam = await _examRepository.UpdateExamAsync(exam);

        return _mapper.Map<ExamDto>(updatedExam);
    }
}
