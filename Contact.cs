namespace HwCreateGame
{
    public class Contact
    {
        public string Name { get; private set; }
        public string Surname { get; private set; }
        public string Phone { get; private set; }

        public Contact(string name, string surname, string phone)
        {
            Name = name;
            Surname = surname;
            Phone = phone;
        }
    }
}