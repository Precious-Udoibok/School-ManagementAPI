
using Microsoft.EntityFrameworkCore;
using SchoolManagement.Domain;
using SchoolManagement.Domain.UserManagement;

namespace SchoolManagement.Persistence
{
    public class SchoolManagementDbContext : DbContext
    {
        public SchoolManagementDbContext(DbContextOptions<SchoolManagementDbContext> options)
           : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Lecturer> Lecturer { get; set; }
        public DbSet<CourseRegistration> CourseRegistrations { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<College> Colleges { get; set; }

    }
}
