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

public class FacultyService : IFacultyService
{
    private readonly IFacultyRepository _facultyRepository;
    private readonly IMapper _mapper;

    public FacultyService(IFacultyRepository facultyRepository, IMapper mapper)
    {
        _facultyRepository = facultyRepository;
        _mapper = mapper;
    }
    public async Task<FacultyDto> AddFacultyAsync(FacultyRequest facultyRequest)
    {
        var faculty = await _facultyRepository.AddFacultyAsync(_mapper.Map<Faculty>(facultyRequest));

        return _mapper.Map<FacultyDto>(faculty);
    }

    public async Task<FacultyDto> DeleteFacultyAsync(int id)
    {
        var faculty = await _facultyRepository.GetFacultyByIdAsync(id);

        if (faculty is null) { throw new NotFoundException("There is not any faculty with such an id"); }

        var deletedFaculty = await _facultyRepository.DeleteFacultyAsync(faculty);

        return _mapper.Map<FacultyDto>(deletedFaculty);
    }

    public async Task<List<FacultyDto>> GetAllFacultiesAsync()
    {
        var faculties = await _facultyRepository.GetAllFacultiesAsync();

        return _mapper.Map<List<FacultyDto>>(faculties);
    }

    public async Task<FacultyDto> GetFacultyByIdAsync(int id)
    {
        var faculty = await _facultyRepository.GetFacultyByIdAsync(id);

        if (faculty is null) { throw new NotFoundException("There is not any faculty with such an id"); }

        return _mapper.Map<FacultyDto>(faculty);
    }

    public async Task<FacultyDto> UpdateFacultyAsync(FacultyRequest facultyRequest)
    {
        var faculty = await _facultyRepository.GetFacultyByIdAsync(facultyRequest.Id);

        if (faculty is null) { throw new NotFoundException("There is not any faculty with such an id"); }

        _mapper.Map(facultyRequest, faculty);

        var facultyUpdated = await _facultyRepository.UpdateFacultyAsync(faculty);
        
        return _mapper.Map<FacultyDto>(facultyUpdated);
    }
}
