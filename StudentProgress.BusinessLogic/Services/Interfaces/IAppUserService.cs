using StudentProgress.BusinessLogic.Profiles.Dtos;
using StudentProgress.BusinessLogic.Requests;

namespace StudentProgress.BusinessLogic.Services.Interfaces;

public interface IAppUserService
{
    Task<AppUserDto> AddAsync(AppUserRequest request);
    Task<AppUserDto> UpdateAsync(AppUserRequest request);
    Task<AppUserDto> DeleteAsync(AppUserRequest request);
    Task<AppUserDto> GetUserById(int id);
    Task<List<AppUserDto>> GetAllUsersAsync();
    Task<string> LoginAsync(UserLogin userLogin);
}
