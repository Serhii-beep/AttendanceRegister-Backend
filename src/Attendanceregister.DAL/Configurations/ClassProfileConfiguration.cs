using Attendanceregister.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Attendanceregister.DAL.Configurations
{
    public class ClassProfileConfiguration : IEntityTypeConfiguration<ClassProfile>
    {
        public void Configure(EntityTypeBuilder<ClassProfile> builder)
        {
            builder.Property(cp => cp.ProfileName).IsRequired();
        }
    }
}
