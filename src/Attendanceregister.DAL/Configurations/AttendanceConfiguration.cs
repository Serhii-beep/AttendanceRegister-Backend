using Attendanceregister.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Attendanceregister.DAL.Configurations
{
    internal class AttendanceConfiguration : IEntityTypeConfiguration<Attendance>
    {
        public void Configure(EntityTypeBuilder<Attendance> builder)
        {
            builder.Property(e => e.Note).IsRequired().HasColumnType("nvarchar(1500)");

            builder.HasOne(a => a.Lesson)
                .WithMany(l => l.Attendances)
                .HasForeignKey(a => a.LessonId)
                .HasConstraintName("CN_Attendances_Lessons")
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(a => a.Pupil)
                .WithMany(p => p.Attendances)
                .HasForeignKey(a => a.PupilId)
                .HasConstraintName("CN_Attendances_Pupils")
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
