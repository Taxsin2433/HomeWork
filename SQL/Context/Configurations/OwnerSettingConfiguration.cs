using EFCore1.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFCore1.Context.Configurations
{
    public class OwnerSettingConfiguration : IEntityTypeConfiguration<OwnerSettings>
    {
        public void Configure(EntityTypeBuilder<OwnerSettings> builder)
        {
            builder
                .Property(x => x.Theme)
                .HasConversion(
                    v => v.ToString(),
                    v => (ClinicTheme)Enum.Parse(typeof(ClinicTheme), v)
                );
            builder
                .HasOne(x => x.Owner)
                .WithOne(x => x.OwnerSettings)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
