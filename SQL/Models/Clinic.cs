using SQL.Models;

public class Clinic
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public string? ListOfServices { get; set; }
    public string? AdressOfClinic { get; set; } 

    // *-* 
    public ICollection<Owner>? Patients { get; set; }

    // 1-* 
    public ICollection<MedicalRecord>? MedicalRecords { get; set; }
}
