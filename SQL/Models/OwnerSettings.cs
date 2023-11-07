using SQL.Models;

namespace EFCore1.Models
{
    public enum ClinicTheme
    {
        Standard, Pediatric, Veterinary
    }

    public class OwnerSettings
    {
        public Guid Id { get; set; }
        public ClinicTheme Theme { get; set; }

        // 1-1 
        public int OwnerId { get; set; }
        public Owner? Owner { get; set; }
    }
}
