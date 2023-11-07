namespace EFCore1.DTOs
{
    public class OwnerDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }

        public IEnumerable<ClinicDto> Subscriptions { get; set; }
    }

    public class ClinicDto
    {
        public int Id { get; set; }
        public required string Name { get; set; }
    }
}
