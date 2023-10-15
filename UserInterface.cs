namespace HwCreateGame
{
    public class UserInterface
    {
        private IContactList _contactList;
        private FileHandler _fileHandler;
        private IConsoleManager _consoleManager;

        public UserInterface(IContactList contactList, FileHandler fileHandler, IConsoleManager consoleManager)
        {
            this._contactList = contactList;
            this._fileHandler = fileHandler;
            this._consoleManager = consoleManager;
        }

        public async Task ProcessUserCommands()
        {
            while (true)
            {
                _consoleManager.DisplayMessage("Введите команду (1 - Добавить, 2 - Найти, 3 - Отобразить список, 4 - Выйти, 5 - Удалить):");
                string command = Console.ReadLine();

                switch (command.ToLower())
                {
                    case "1":
                       await AddContact();
                        break;
                    case "2":
                        SearchContacts();
                        break;
                    case "3":
                        await DisplayAllContactsAsync();
                        break;
                    case "4":
                        return;
                    case "5":
                        DeleteContact();
                        break;
                    default:
                        _consoleManager.DisplayMessage("Неверная команда. Пожалуйста, попробуйте снова.");
                        break;
                }
            }
        }

        private async Task AddContact()
        {
            _consoleManager.DisplayMessage("Введите данные контакта:");
            _consoleManager.DisplayMessage("Имя: ");
            string name = Console.ReadLine();
            _consoleManager.DisplayMessage("Фамилия: ");
            string surname = Console.ReadLine();
            _consoleManager.DisplayMessage("Телефон: ");
            string phone = Console.ReadLine();

            Contact contact = new Contact(name, surname, phone);
            _contactList.AddContact(contact);
            await _fileHandler.WriteContactsToFileAsync(_contactList.GetAllContacts().ToList());
        }

        private void SearchContacts()
        {
            _consoleManager.DisplayMessage("Введите параметр поиска:");
            string parameter = Console.ReadLine();

            var searchResults = _contactList.SearchContacts(parameter);
            if (searchResults.Count > 0)
            {
                _consoleManager.DisplayMessage("Результаты поиска:");
                foreach (var contact in searchResults)
                {
                    _consoleManager.DisplayMessage($"Имя: {contact.Name}, Фамилия: {contact.Surname}, Телефон: {contact.Phone}");
                }
            }
            else
            {
                _consoleManager.DisplayMessage("Контакты не найдены.");
            }
        }

        private async Task DisplayAllContactsAsync()
        {
            _consoleManager.DisplayMessage("Список контактов:");

            // Read contacts from the file using the FileHandler
            List<Contact> savedContacts = await _fileHandler.ReadContactsFromFileAsync();

            // Update the contact list with the saved contacts
            _contactList.UpdateContacts(savedContacts);

            foreach (var contact in savedContacts)
            {
                _consoleManager.DisplayMessage($"Имя: {contact.Name}, Фамилия: {contact.Surname}, Телефон: {contact.Phone}");
            }
        }

        private void DeleteContact()
        {
            _consoleManager.DisplayMessage("Введите имя контакта для удаления:");
            string name = Console.ReadLine();

            var contact = _contactList.GetAllContacts().ToList().Find(c => c.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
            if (contact != null)
            {
                _contactList.DeleteContact(contact);
                _consoleManager.DisplayMessage("Контакт успешно удален.");
            }
            else
            {
                _consoleManager.DisplayMessage("Контакт не найден.");
            }
        }
    }
}
