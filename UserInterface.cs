using System;
using System.Collections.Generic;
using System.IO;

namespace HwCreateGame
{
    public class UserInterface
    {
        private ContactList contactList;
        private FileHandler fileHandler;
        private bool canWriteToFile;

        public UserInterface(ContactList contactList, FileHandler fileHandler, bool canWriteToFile)
        {
            this.contactList = contactList;
            this.fileHandler = fileHandler;
            this.canWriteToFile = canWriteToFile;
        }

        // Метод обработки команд пользователя
        public void ProcessUserCommands()
        {
            while (true)
            {
                Console.WriteLine("Введите команду (1 - Добавить, 2 - Найти, 3 - Отобразить список, 4 - Выйти, 5 - Удалить):");
                string command = Console.ReadLine();

                switch (command.ToLower())
                {
                    case "1":
                        if (canWriteToFile)
                        {
                            AddContact();
                        }
                        else
                        {
                            Console.WriteLine("Запись в файл разрешена только в одном экземпляре приложения.");
                        }
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
                        if (canWriteToFile)
                        {
                            DeleteContact();
                        }
                        else
                        {
                            Console.WriteLine("Удаление контакта разрешено только в одном экземпляре приложения.");
                        }
                        break;
                    default:
                        Console.WriteLine("Неверная команда. Пожалуйста, попробуйте снова.");
                        break;
                }
            }
        }

        // Метод добавления контакта
        private void AddContact()
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

        // Метод поиска контактов
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

        // Метод отображения всех контактов
        private void DisplayAllContacts()
        {
            // Считываем сохраненный список контактов перед выводом
            List<Contact> savedContacts = fileHandler.ReadContactsFromFile();
            contactList.UpdateContacts(savedContacts);

            Console.WriteLine("Список контактов:");
            foreach (var contact in savedContacts)
            {
                Console.WriteLine($"Имя: {contact.Name}, Фамилия: {contact.Surname}, Телефон: {contact.Phone}");
            }
        }

        // Метод удаления контакта
        private void DeleteContact()
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
