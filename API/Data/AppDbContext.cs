using Microsoft.EntityFrameworkCore;
using API.Models;

namespace API.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<CourseInfo> Courses { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Assignment> Assignments { get; set; }
        public DbSet<Module> Modules { get; set; }
        public DbSet<ContentItem> ContentItems { get; set; }
        public DbSet<AssignmentSubmission> AssignmentSubmissions { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<CourseInfo>()
                .HasMany(c => c.Roster)
                .WithMany()
                .UsingEntity(j => j.ToTable("CourseStudentEnrollment"));
        }
    }
}
