using System;
using System.Collections.Generic;
using System.Linq;

namespace HwCreateGame
{
    public class ContactList
    {
        private readonly List<Contact> contacts = new List<Contact>();

        public void AddContact(Contact contact)
        {
            contacts.Add(contact);
        }

        public List<Contact> SearchContacts(string parameter)
        {
            return contacts.Where(c =>
                c.Name.Contains(parameter, StringComparison.OrdinalIgnoreCase) ||
                c.Surname.Contains(parameter, StringComparison.OrdinalIgnoreCase) ||
                c.Phone.Contains(parameter, StringComparison.OrdinalIgnoreCase)).ToList();
        }

        public void DisplayAllContacts()
        {
            Console.WriteLine("Список контактов:");
            foreach (var contact in contacts)
            {
                Console.WriteLine($"Имя: {contact.Name}, Фамилия: {contact.Surname}, Телефон: {contact.Phone}");
            }
        }

        public void DeleteContact(Contact contact)
        {
            contacts.Remove(contact);
        }

        public List<Contact> GetAllContacts()
        {
            return contacts;
        }
    }
}
