using System;
using System.Collections.Generic;

namespace HwCreateGame
{
    public class ContactList : IContactList
    {
        private SortedSet<Contact> contacts;
        private IConsoleManager consoleManager;

        public ContactList(IConsoleManager consoleManager)
        {
            contacts = new SortedSet<Contact>(new ContactComparer());
            this.consoleManager = consoleManager;
        }

        public void AddContact(Contact contact)
        {
            contacts.Add(contact);
        }

        public IList<Contact> SearchContacts(string parameter)
        {
            parameter = parameter.ToLower();

            var searchResults = new List<Contact>();
            foreach (var contact in contacts)
            {
                if (contact.Name.IndexOf(parameter, StringComparison.OrdinalIgnoreCase) >= 0 ||
                    contact.Surname.IndexOf(parameter, StringComparison.OrdinalIgnoreCase) >= 0 ||
                    contact.Phone.IndexOf(parameter, StringComparison.OrdinalIgnoreCase) >= 0)
                {
                    searchResults.Add(contact);
                }
            }

            return searchResults;
        }

        public void DisplayAllContacts()
        {
            consoleManager.DisplayMessage("Список контактов:");
            foreach (var contact in contacts)
            {
                consoleManager.DisplayMessage($"Имя: {contact.Name}, Фамилия: {contact.Surname}, Телефон: {contact.Phone}");
            }
        }

        public void DeleteContact(Contact contact)
        {
            contacts.Remove(contact);
        }

        public IList<Contact> GetAllContacts()
        {
            return new List<Contact>(contacts);
        }

        public void UpdateContacts(IList<Contact> newContacts)
        {
            contacts.Clear();
            foreach (var contact in newContacts)
            {
                contacts.Add(contact);
            }
        }

    }

    // Custom comparer to sort contacts by name
    public class ContactComparer : IComparer<Contact>
    {
        public int Compare(Contact x, Contact y)
        {
            return string.Compare(x.Name, y.Name, StringComparison.OrdinalIgnoreCase);
        }
    }
}
