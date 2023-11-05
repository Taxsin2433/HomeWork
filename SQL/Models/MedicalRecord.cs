using SQL.Models;

public class MedicalRecord
{
    public int Id { get; set; }
    public string Text { get; set; }

    // 1-* 
    public Clinic Clinic { get; set; }

    // *-* 
    public ICollection<Owner> MedicalOwners { get; set; }
}

