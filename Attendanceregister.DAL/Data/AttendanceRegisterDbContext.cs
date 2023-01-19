using Attendanceregister.DAL.Configurations;
using Attendanceregister.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace Attendanceregister.DAL.Data
{
    public class AttendanceRegisterDbContext : DbContext
    {
        public virtual DbSet<Admin> Admins { get; set; }
        public virtual DbSet<Attendance> Attendances { get; set; }
        public virtual DbSet<Class> Classes { get; set; }
        public virtual DbSet<Lesson> Lessons { get; set; }
        public virtual DbSet<Mark> Marks { get; set; }
        public virtual DbSet<Pupil> Pupils { get; set; }
        public virtual DbSet<Subject> Subjects { get; set; }
        public virtual DbSet<SubjectClass> SubjectClasses { get; set; }
        public virtual DbSet<Teacher> Teachers { get; set; }
        public virtual DbSet<TeacherSubject> TeacherSubjects { get; set; }

        public AttendanceRegisterDbContext(DbContextOptions<AttendanceRegisterDbContext> options) : base(options)
        { }
     
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AdminConfiguration());

            modelBuilder.ApplyConfiguration(new AttendanceConfiguration());

            modelBuilder.ApplyConfiguration(new ClassConfiguration());

            modelBuilder.ApplyConfiguration(new LessonConfiguration());

            modelBuilder.ApplyConfiguration(new MarkConfiguration());

            modelBuilder.ApplyConfiguration(new PupilConfiguration());

            modelBuilder.ApplyConfiguration(new SubjectClassConfiguration());

            modelBuilder.ApplyConfiguration(new SubjectConfiguration());

            modelBuilder.ApplyConfiguration(new TeacherConfiguration());

            modelBuilder.ApplyConfiguration(new TeacherSubjectConfiguration());
        }
    }
}
