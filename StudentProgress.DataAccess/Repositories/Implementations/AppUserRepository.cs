using Microsoft.EntityFrameworkCore;
using StudentProgress.DataAccess.Data;
using StudentProgress.DataAccess.Entities;
using StudentProgress.DataAccess.Repositories.Interfaces;

namespace StudentProgress.DataAccess.Repositories.Implementations
{
    public class AppUserRepository : IAppUserRepository
    {
        private readonly ApplicationDbContext _context;

        /// <summary>
        /// Initializes a new instance of <see cref="AppUserRepository"
        /// </summary>
        /// <param name="context"></param>
        public AppUserRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<AppUser> AddAsync(AppUser appuser)
        {
            _context.AppUsers.Add(appuser);
            await _context.SaveChangesAsync();

            return appuser;
        }

        public async Task<AppUser> DeleteAsync(AppUser appUser)
        {
            _context.AppUsers.Remove(appUser);
            await _context.SaveChangesAsync();

            return appUser;
        }

        public async Task<List<AppUser>> GetAllUsersAsync()
        {
            return await _context.AppUsers.ToListAsync();
        }

        public async Task<AppUser?> GetUserByEmailAsync(string email)
        {
            return await _context.AppUsers
                .Include(user => user.Role)
                .FirstOrDefaultAsync(user => user.Email.Equals(email));
        }

        public async Task<AppUser?> GetUserByIdAsync(int id)
        {
            return await _context.AppUsers
                .Include(user => user.Role)
                .FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task<AppUser> UpdateAsync(AppUser user)
        {
            _context.AppUsers.Update(user);
            await _context.SaveChangesAsync();

            return user;
        }
    }
}
