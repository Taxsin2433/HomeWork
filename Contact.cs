using System;

namespace HwCreateGame
{
    public class Contact
    {
        public string Name { get; }
        public string Surname { get; }
        public string Phone { get; }

        public Contact(string name, string surname, string phone)
        {
            Name = name;
            Surname = surname;
            Phone = phone;
        }
    }
}
