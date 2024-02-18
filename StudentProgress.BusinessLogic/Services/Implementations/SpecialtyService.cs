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
public class SpecialtyService : ISpecialtyService
{
    private readonly ISpecialtyRepository _specialtyRepository;
    private readonly IMapper _mapper;
    public SpecialtyService(ISpecialtyRepository specialtyRepository, IMapper mapper)
    {
        _specialtyRepository = specialtyRepository;
        _mapper = mapper;
    }

    public async Task<SpecialtyDto> AddSpecialtyAsync(SpecialtyRequest specialtyRequest)
    {
        var specialty = await _specialtyRepository.AddSpecialtyAsync(_mapper.Map<Specialty>(specialtyRequest));

        return _mapper.Map<SpecialtyDto>(specialty);
    }

    public async Task<SpecialtyDto> DeleteSpecialty(int id)
    {
        var specialty = await _specialtyRepository.GetSpecialtyByIdAsync(id);

        if (specialty is null) { throw new NotFoundException("There is not any specialty with such an id"); }

        var deletedSpecialty = await _specialtyRepository.DeleteSpecialtyAsync(specialty);

        return _mapper.Map<SpecialtyDto>(deletedSpecialty);
    }

    public async Task<List<SpecialtyDto>> GetAllSpecialtiesAsync()
    {
        var specilaties = await _specialtyRepository.GetAllSpecialtiesAsync();

        return _mapper.Map<List<SpecialtyDto>>(specilaties);
    }

    public async Task<SpecialtyDto> GetSpecialtyByIdAsync(int id)
    {
        var specialty = await _specialtyRepository.GetSpecialtyByIdAsync(id);

        if (specialty is null) { throw new NotFoundException("There is not any specialty with such an id"); }

        return _mapper.Map<SpecialtyDto>(specialty);
    }

    public async Task<SpecialtyDto> UpdateSpecialtyAsync(SpecialtyRequest specialtyRequest)
    {
        var specialty = await _specialtyRepository.GetSpecialtyByIdAsync(specialtyRequest.Id);

        if(specialty is null) { throw new NotFoundException("There is not any specialty with such an id"); }

        _mapper.Map(specialtyRequest, specialty);

        var updatedSpecialty = await _specialtyRepository.UpdateSpecialtyAsync(specialty);

        return _mapper.Map<SpecialtyDto>(updatedSpecialty);
    }
}
