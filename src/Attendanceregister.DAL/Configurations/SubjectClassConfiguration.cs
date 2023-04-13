using Attendanceregister.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Attendanceregister.DAL.Configurations
{
    internal class SubjectClassConfiguration : IEntityTypeConfiguration<SubjectClass>
    {
        public void Configure(EntityTypeBuilder<SubjectClass> builder)
        {
            builder.HasOne(sc => sc.Class)
                .WithMany(c => c.SubjectClasses)
                .HasForeignKey(sc => sc.ClassId)
                .HasConstraintName("CN_SubjectClasses_Classes")
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(sc => sc.Subject)
                .WithMany(s => s.SubjectClasses)
                .HasForeignKey(sc => sc.SubjectId)
                .HasConstraintName("CN_SubjectClasses_Subjects")
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
