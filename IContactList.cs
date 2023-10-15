using System.Collections.Generic;

namespace HwCreateGame
{
    public interface IContactList
    {
        void AddContact(Contact contact);
        IList<Contact> SearchContacts(string parameter);
        void DisplayAllContacts();
        void DeleteContact(Contact contact);
        IList<Contact> GetAllContacts();
        void UpdateContacts(IList<Contact> newContacts);
    }
}
