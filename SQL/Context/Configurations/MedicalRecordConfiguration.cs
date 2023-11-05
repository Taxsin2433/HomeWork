using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFCore1.Context.Configurations
{
    public class MedicalRecordConfiguration : IEntityTypeConfiguration<MedicalRecord>
        {
            public void Configure(EntityTypeBuilder<MedicalRecord> builder)
            {
                builder.HasOne(x => x.Clinic).WithMany(x => x.MedicalRecords);
                builder.HasMany(x => x.MedicalOwners).WithMany(x => x.MedicalRecords);
            }
        }      
}
