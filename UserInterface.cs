using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HwCreateGame
{
    public class UserInterface
    {
        private readonly ContactList contactList;
        private readonly FileHandler fileHandler;

        public UserInterface(ContactList contactList, FileHandler fileHandler)
        {
            this.contactList = contactList;
            this.fileHandler = fileHandler;
        }

        public async Task ProcessUserCommandsAsync()
        {
            while (true)
            {
                Console.WriteLine("Введите команду (1 - Добавить, 2 - Найти, 3 - Отобразить список, 4 - Выйти, 5 - Удалить):");
                string command = Console.ReadLine();

                switch (command.ToLower())
                {
                    case "1":
                        await AddContactAsync();
                        break;
                    case "2":
                        SearchContacts();
                        break;
                    case "3":
                        DisplayAllContacts();
                        break;
                    case "4":
                        return;
                    case "5":
                        await DeleteContactAsync();
                        break;
                    default:
                        Console.WriteLine("Неверная команда. Пожалуйста, попробуйте снова.");
                        break;
                }
            }
        }

        private async Task AddContactAsync()
        {
            Console.WriteLine("Введите данные контакта:");
            Console.Write("Имя: ");
            string name = Console.ReadLine();
            Console.Write("Фамилия: ");
            string surname = Console.ReadLine();
            Console.Write("Телефон: ");
            string phone = Console.ReadLine();

            Contact contact = new Contact(name, surname, phone);
            contactList.AddContact(contact);
        }

        private void SearchContacts()
        {
            Console.WriteLine("Введите параметр поиска:");
            string parameter = Console.ReadLine();

            List<Contact> searchResults = contactList.SearchContacts(parameter);
            if (searchResults.Count > 0)
            {
                Console.WriteLine("Результаты поиска:");
                foreach (var contact in searchResults)
                {
                    Console.WriteLine($"Имя: {contact.Name}, Фамилия: {contact.Surname}, Телефон: {contact.Phone}");
                }
            }
            else
            {
                Console.WriteLine("Контакты не найдены.");
            }
        }

        private void DisplayAllContacts()
        {
            List<Contact> savedContacts = fileHandler.ReadContactsFromFile();
            // Очищаем текущие контакты в contactList
            foreach (var contact in contactList.GetAllContacts())
            {
                contactList.DeleteContact(contact);
            }
            // Добавляем новые контакты
            foreach (var contact in savedContacts)
            {
                contactList.AddContact(contact);
            }

            Console.WriteLine("Список контактов:");
            foreach (var contact in savedContacts)
            {
                Console.WriteLine($"Имя: {contact.Name}, Фамилия: {contact.Surname}, Телефон: {contact.Phone}");
            }
        }

        private async Task DeleteContactAsync()
        {
            Console.WriteLine("Введите имя контакта для удаления:");
            string name = Console.ReadLine();

            Contact contact = contactList.GetAllContacts().FirstOrDefault(c => c.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
            if (contact != null)
            {
                contactList.DeleteContact(contact);
                Console.WriteLine("Контакт успешно удален.");
            }
            else
            {
                Console.WriteLine("Контакт не найден.");
            }
        }
    }
}
