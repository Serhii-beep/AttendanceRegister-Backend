using Attendanceregister.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Attendanceregister.DAL.Configurations
{
    internal class ClassConfiguration : IEntityTypeConfiguration<Class>
    {
        public void Configure(EntityTypeBuilder<Class> builder)
        {
            builder.Property(e => e.Name).IsRequired().HasColumnType("nvarchar(30)");

            builder.Property(e => e.TeacherId).HasDefaultValue(1);

            builder.HasOne(c => c.ClassProfile)
                .WithMany(cp => cp.Classes)
                .HasForeignKey(c => c.ClassProfileId)
                .HasConstraintName("CN_Classes_ClassProfiles");

            builder.HasOne(c => c.Teacher)
                .WithMany(t => t.Classes)
                .HasForeignKey(c => c.TeacherId)
                .HasConstraintName("CN_Classes_Teachers");
        }
    }
}
