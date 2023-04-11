using Attendanceregister.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Attendanceregister.DAL.Configurations
{
    internal class PupilConfiguration : IEntityTypeConfiguration<Pupil>
    {
        public void Configure(EntityTypeBuilder<Pupil> builder)
        {
            builder.Property(e => e.FullName).IsRequired().HasColumnType("nvarchar(100)");

            builder.Property(e => e.Email).IsRequired().HasColumnType("nvarchar(75)");

            builder.Property(e => e.Address).IsRequired().HasColumnType("nvarchar(230)");

            builder.Property(e => e.BirthDate).IsRequired();

            builder.Property(e => e.Login).IsRequired().HasColumnType("nvarchar(30)");

            builder.Property(e => e.Password).IsRequired().HasColumnType("nvarchar(30)");

            builder.HasOne(p => p.Class)
                .WithMany(c => c.Pupils)
                .HasForeignKey(p => p.ClassId)
                .HasConstraintName("CN_Pupils_Classes")
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
