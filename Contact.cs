using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HwCreateGame
{
    public class Contact
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Phone { get; set; }

        public Contact(string name, string surname, string phone)
        {
            Name = name;
            Surname = surname;
            Phone = phone;
        }
    }
}
