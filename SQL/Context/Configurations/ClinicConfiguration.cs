using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SQL.Models;

namespace EFCore1.Context.Configurations
{
    public class ClinicConfiguration : IEntityTypeConfiguration<Clinic>
    {
        public void Configure(EntityTypeBuilder<Clinic> builder)
        {
            builder.HasMany(x => x.MedicalRecords).WithOne(x => x.Clinic);
            builder
                .HasMany(x => x.Patients)
                .WithMany(x => x.ClinicSubscriptions)
                .UsingEntity(
                    l => l.HasOne(typeof(Owner)).WithMany().HasForeignKey("Patient"),
                    r => r.HasOne(typeof(Clinic)).WithMany().HasForeignKey("ClinicSubscriptionsId"));
        }

    }
}
