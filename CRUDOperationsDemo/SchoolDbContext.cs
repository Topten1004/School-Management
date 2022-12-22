using CRUDOperationsDemo.Models;
using Microsoft.EntityFrameworkCore;
using School.Models;

namespace CRUDOperationsDemo
{
    public class SchoolDbContext : DbContext
    {
        public SchoolDbContext(DbContextOptions<SchoolDbContext> options) : base(options)   
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<User> users { get; set; }
        public DbSet<Subject> subjects { get; set; }
        public DbSet<Enrollment> enrolls { get; set; }
        public DbSet<SemesterTeacherSubject> semesterTeacherSubjects { get; set; }
        public DbSet<Semester> semesters { get; set; }
        public DbSet<SemesterAchrayus> semesterAchrayus { get; set; }
        public DbSet<SubjectAttendance> subjectAttendance { get; set; }
        public DbSet<StudentAbsense> studentAbsenses { get; set; }
    }
 }
