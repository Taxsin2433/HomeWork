using EFCore1.Models;

namespace SQL.Models
{
    public class Owner
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Surname { get; set; } = string.Empty;
        public string Adress { get; set; } = string.Empty; 
            public DateOnly? Birthday { get; set; }

        // 1-1 
        public OwnerSettings? OwnerSettings { get; set; }

        // *-* 
        public ICollection<Clinic> ClinicSubscriptions { get; set; } = new List<Clinic>();

        // *-* 
        public ICollection<MedicalRecord> MedicalRecords { get; set; } = new List<MedicalRecord>();
    }
}
