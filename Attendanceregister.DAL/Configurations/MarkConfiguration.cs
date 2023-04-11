using Attendanceregister.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Attendanceregister.DAL.Configurations
{
    internal class MarkConfiguration : IEntityTypeConfiguration<Mark>
    {
        public void Configure(EntityTypeBuilder<Mark> builder)
        {
            builder.HasOne(m => m.Lesson)
                .WithMany(l => l.Marks)
                .HasForeignKey(m => m.LessonId)
                .HasConstraintName("CN_Marks_Lessons")
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(m => m.Pupil)
                .WithMany(p => p.Marks)
                .HasForeignKey(m => m.PupilId)
                .HasConstraintName("CN_Marks_Pupils")
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
