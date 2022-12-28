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
        }
    }
}
