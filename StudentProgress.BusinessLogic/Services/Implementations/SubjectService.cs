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

public class SubjectService : ISubjectService
{
    private readonly ISubjectRepository _subjectRepository;
    private readonly IMapper _mapper;
    public SubjectService(ISubjectRepository subjectRepository, IMapper mapper)
    {
        _subjectRepository = subjectRepository;
        _mapper = mapper;
    }

    public async Task<SubjectDto> AddSubjectAsync(SubjectRequest subjectRequest)
    {
        var subject = await _subjectRepository.AddSubjectAsync(_mapper.Map<Subject>(subjectRequest));

        return _mapper.Map<SubjectDto>(subject);
    }

    public async Task<SubjectDto> DeleteSubjectAsync(int id)
    {
        var subject = await _subjectRepository.GetSubjectByIdAsync(id);

        if(subject is null) { throw new NotFoundException("There is not a subject with such an id"); }

        var subjectDeleted = await _subjectRepository.DeleteSubjectAsync(subject);

        return _mapper.Map<SubjectDto>(subjectDeleted);
    }

    public async Task<List<SubjectDto>> GetAllSubjectsAsync()
    {
        var subjects = await _subjectRepository.GetAllSubjectsAsync();

        return _mapper.Map<List<SubjectDto>>(subjects);
    }

    public async Task<SubjectDto> GetSubjectByIdAsync(int id)
    {
        var subject = await _subjectRepository.GetSubjectByIdAsync(id);

        if(subject is null) { throw new NotFoundException("There is not any subject with the id provided"); }

        return _mapper.Map<SubjectDto>(subject);
    }

    public async Task<SubjectDto> UpdateSubjectAsync(SubjectRequest subjectRequest)
    {
        var subject = await _subjectRepository.GetSubjectByIdAsync(subjectRequest.Id);

        if(subject is null) { throw new NotFoundException("There is not any subject with the provided id"); }

        _mapper.Map(subjectRequest, subject);

        var updatedSubject = await _subjectRepository.UpdateSubjectAsync(subject);

        return _mapper.Map<SubjectDto>(updatedSubject);
    }
}
