using EFCore1.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SQL.Models;

namespace EFCore1.Context.Configurations
{
    public class OwnerConfiguration : IEntityTypeConfiguration<Owner>
    {
        public void Configure(EntityTypeBuilder<Owner> builder)
        {
            builder.Property(b => b.Name).IsRequired();
            builder.Property(b => b.Surname).IsRequired();

            builder
                .Property(x => x.Birthday)
                .HasConversion(new ValueConverter<DateOnly?, DateTime?>(
                    x => x.HasValue ? x.Value.ToDateTime(TimeOnly.MinValue) : null,
                    y => y.HasValue ? DateOnly.FromDateTime(y.Value) : null)
                );

            builder
                .HasOne(x => x.OwnerSettings)
                .WithOne(x => x.Owner)
                .OnDelete(DeleteBehavior.ClientSetNull);

            builder.HasMany(x => x.MedicalRecords).WithMany(x => x.MedicalOwners);
            builder
                .HasMany(x => x.ClinicSubscriptions)
                .WithMany(x => x.Patients)
                .UsingEntity(
                    l => l.HasOne(typeof(Owner)).WithMany().HasForeignKey("PatientsId"),
                    r => r.HasOne(typeof(Clinic)).WithMany().HasForeignKey("ClinicSubscriptionsId"));
        }


    }
}
