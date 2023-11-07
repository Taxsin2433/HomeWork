public class Pet
{
    public int Id { get; set; }
    public string Name { get; set; }
    public ICollection<Client> Owners { get; set; }
}