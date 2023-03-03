using Attendanceregister.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Attendanceregister.DAL.Configurations
{
    internal class LessonConfiguration : IEntityTypeConfiguration<Lesson>
    {
        public void Configure(EntityTypeBuilder<Lesson> builder)
        {
            builder.Property(e => e.Theme).IsRequired().HasColumnType("nvarchar(75)");

            builder.Property(e => e.Date).IsRequired();

            builder.HasOne(l => l.SubjectClass)
                .WithMany(sc => sc.Lessons)
                .HasForeignKey(l => l.SubjectClassId)
                .HasConstraintName("CN_Lessons_SubjectClasses")
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
