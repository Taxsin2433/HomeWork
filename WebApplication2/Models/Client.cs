public class Client
{
    public int Id { get; set; }
    public string Name { get; set; }
    public ClientSettings Settings { get; set; }
    public ICollection<Pet> Pets { get; set; }
}