using Microsoft.EntityFrameworkCore;
using StudentProgress.DataAccess.Data;
using StudentProgress.DataAccess.Entities;
using StudentProgress.DataAccess.Repositories.Interfaces;

namespace StudentProgress.DataAccess.Repositories.Implementations
{
    /// <summary>
    /// implemented Test's repository class
    /// </summary>
    public class TestRepository : ITestRepository
    {
        /// <summary>
        /// injected application DbContext object
        /// </summary>
        private readonly ApplicationDbContext _context;
        public TestRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Method to add test
        /// </summary>
        /// <param name="test"></param>
        /// <returns>test</returns>
        public async Task<Test> AddTestAsync(Test test)
        {
            _context.Tests.Add(test);
            await _context.SaveChangesAsync();

            return test;
        }

        /// <summary>
        /// Method to delete test
        /// </summary>
        /// <param name="test"></param>
        /// <returns>test</returns>
        public async Task<Test> DeleteTestAsync(Test test)
        {
            _context.Tests.Remove(test);
            await _context.SaveChangesAsync();

            return test;
        }

        /// <summary>
        /// Method to get all test
        /// </summary>
        /// <returns>list of test</returns>
        public async Task<List<Test>> GetAllTestAsync()
        {
            return await _context.Tests
                .Include(s => s.Subject)
                .AsNoTracking()
                .ToListAsync();
        }

        /// <summary>
        /// Method to get test by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>test</returns>
        public async Task<Test?> GetTestByIdAsync(int id)
        {
            return await _context.Tests.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
        }

        /// <summary>
        /// Method to update test
        /// </summary>
        /// <param name="test"></param>
        /// <returns>test</returns>
        public async Task<Test> UpdateTestAsync(Test test)
        {
            _context.Tests.Update(test);
            await _context.SaveChangesAsync();

            return test;
        }
    }
}
