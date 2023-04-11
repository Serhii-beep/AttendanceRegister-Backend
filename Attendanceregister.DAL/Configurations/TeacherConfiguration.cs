using Attendanceregister.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Attendanceregister.DAL.Configurations
{
    internal class TeacherConfiguration : IEntityTypeConfiguration<Teacher>
    {
        public void Configure(EntityTypeBuilder<Teacher> builder)
        {
            builder.Property(e => e.FullName).IsRequired().HasColumnType("nvarchar(100)");

            builder.Property(e => e.Email).IsRequired().HasColumnType("nvarchar(75)");

            builder.Property(e => e.Login).IsRequired().HasColumnType("nvarchar(30)");

            builder.Property(e => e.Password).IsRequired().HasColumnType("nvarchar(30)");
        }
    }
}
