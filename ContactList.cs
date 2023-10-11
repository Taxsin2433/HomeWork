using HwCreateGame;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class ContactList
{
    private List<Contact> contacts;

    public ContactList()
    {
        contacts = new List<Contact>();
    }

    // Добавление контакта
    public void AddContact(Contact contact)
    {
        contacts.Add(contact);
    }

    // Поиск контактов по параметру
    public List<Contact> SearchContacts(string parameter)
    {
        return contacts.Where(c => c.Name.Contains(parameter) || c.Surname.Contains(parameter) || c.Phone.Contains(parameter)).ToList();
    }

    // Отображение всех контактов
    public void DisplayAllContacts()
    {
        Console.WriteLine("Список контактов:");
        foreach (var contact in contacts)
        {
            Console.WriteLine($"Имя: {contact.Name}, Фамилия: {contact.Surname}, Телефон: {contact.Phone}");
        }
    }

    // Удаление контакта
    public void DeleteContact(Contact contact)
    {
        contacts.Remove(contact);
    }

    // Получение всех контактов
    public List<Contact> GetAllContacts()
    {
        return contacts;
    }

    //FileWatcher
    public void UpdateContacts(List<Contact> newContacts)
    {
        contacts.Clear();
        contacts.AddRange(newContacts);
    }
}



