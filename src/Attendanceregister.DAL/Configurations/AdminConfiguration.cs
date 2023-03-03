using Attendanceregister.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Attendanceregister.DAL.Configurations
{
    internal class AdminConfiguration : IEntityTypeConfiguration<Admin>
    {
        public void Configure(EntityTypeBuilder<Admin> builder)
        {
            builder.Property(e => e.Login).IsRequired().HasColumnType("nvarchar(30)");

            builder.Property(e => e.Password).IsRequired().HasColumnType("nvarchar(30)");
        }
    }
}
