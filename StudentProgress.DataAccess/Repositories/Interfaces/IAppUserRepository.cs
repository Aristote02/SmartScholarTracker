using StudentProgress.DataAccess.Entities;

namespace StudentProgress.DataAccess.Repositories.Interfaces;

public interface IAppUserRepository
{
    Task<List<AppUser>> GetAllUsersAsync();
    Task<AppUser?> GetUserByIdAsync(int id);
    Task<AppUser?> GetUserByEmailAsync(string email);
    Task<AppUser> AddAsync(AppUser appUser);
    Task<AppUser> UpdateAsync(AppUser AppUser);
    Task<AppUser> DeleteAsync(AppUser AppUser);
}
