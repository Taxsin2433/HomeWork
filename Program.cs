using System;
using System.Threading.Tasks;

namespace HwCreateGame
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            string filePath = "contacts.txt";

            bool createdNew;
            Mutex mutex = new Mutex(true, "ContactsFileLock", out createdNew);

            if (createdNew)
            {
                // Разрешаем запись в файл только одному экземпляру
                ContactList contactList = new ContactList();
                FileHandler fileHandler = new FileHandler(filePath);
                UserInterface userInterface = new UserInterface(contactList, fileHandler);
                await userInterface.ProcessUserCommandsAsync();

                // Записываем контакты в файл перед выходом (асинхронно)
                await fileHandler.WriteContactsToFileAsync(contactList.GetAllContacts());

                // Освобождаем Mutex
                mutex.ReleaseMutex();
            }
            else
            {
                // Если Mutex был захвачен другим экземпляром, разрешаем только чтение
                FileHandler fileHandler = new FileHandler(filePath);
                ContactList contactList = new ContactList();

                UserInterface userInterface = new UserInterface(contactList, fileHandler);
                await userInterface.ProcessUserCommandsAsync();
            }
        }
    }
}
