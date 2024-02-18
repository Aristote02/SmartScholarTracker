using Microsoft.EntityFrameworkCore;
using StudentProgress.DataAccess.Data;
using StudentProgress.DataAccess.Entities;
using StudentProgress.DataAccess.Repositories.Interfaces;

namespace StudentProgress.DataAccess.Repositories.Implementations
{
    /// <summary>
    /// Implementing the faculty repository class
    /// </summary>
    public class FacultyRepository : IFacultyRepository
    {
        /// <summary>
        /// Injected application Dbcontext object
        /// </summary>
        private readonly ApplicationDbContext _context;
        public FacultyRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Method to add new faculty
        /// </summary>
        /// <param name="faculty"></param>
        /// <returns>faculty</returns>
        public async Task<Faculty> AddFacultyAsync(Faculty faculty)
        {
            _context.Faculties.Add(faculty);
            await _context.SaveChangesAsync();

            return faculty;
        }

        /// <summary>
        /// method to delete faculty
        /// </summary>
        /// <param name="faculty"></param>
        /// <returns>faculty</returns>
        public async Task<Faculty> DeleteFacultyAsync(Faculty faculty)
        {
            _context.Faculties.Remove(faculty);
            await _context.SaveChangesAsync();

            return faculty;
        }

        /// <summary>
        /// method to Get all faculties
        /// </summary>
        /// <returns>list of faculties</returns>
        public async Task<List<Faculty>> GetAllFacultiesAsync()
        {
            return await _context.Faculties.AsNoTracking().ToListAsync();
        }

        /// <summary>
        /// method to get faculty by id 
        /// </summary>
        /// <param name="id"></param>
        /// <returns>faculty</returns>
        public async Task<Faculty?> GetFacultyByIdAsync(int id)
        {
            return await _context.Faculties.AsNoTracking().FirstOrDefaultAsync(f => f.Id == id);
        }

        /// <summary>
        /// Method to update faculty
        /// </summary>
        /// <param name="faculty"></param>
        /// <returns>faculty</returns>
        public async Task<Faculty> UpdateFacultyAsync(Faculty faculty)
        {
            _context.Faculties.Update(faculty);
            await _context.SaveChangesAsync();

            return faculty;
        }
    }
}
