using Microsoft.EntityFrameworkCore;
using StudentProgress.DataAccess.Entities;

namespace StudentProgress.DataAccess.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) 
            : base(options)
        {
               
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Faculty> Faculties { get; set;}
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Specialty> Specialties { get; set; }
        public DbSet<Exam> Exams { get; set; }
        public DbSet<Test> Tests { get; set; }
        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<Role> Roles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<AppUser>().HasIndex(u => u.Email).IsUnique();
            modelBuilder.Entity<AppUser>().HasKey(u => u.Id);
            modelBuilder.Entity<Role>().HasData(new List<Role>
            {
                new Role
                {
                    Id = -2,
                    Name = "user"
                },
                new Role
                {
                    Id = -1,
                    Name = "admin"
                }
            });

            modelBuilder.Entity<AppUser>().HasData(new AppUser
            {
                Id = -1,
                UserName = "Aristote12",
                Email = "aristote@gmail.com",
                Password = "Aris021122000",
                RoleId = -1,
            });
        }

    }

}
