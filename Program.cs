using HwCreateGame;
using System;
using System.Threading;
using System.Threading.Tasks;

class Program
{
    static async Task Main(string[] args)
    {
        string filePath = "contacts.json";
        bool canWriteToFile = false;
        Mutex mutex = new Mutex(false, "ContactsFileLock");

        try
        {
            if (mutex.WaitOne(TimeSpan.Zero, true))
            {
                canWriteToFile = true;
            }
            else
            {
                Console.WriteLine("Доступ к файлу заблокирован. Разрешена только операция чтения.");
            }
        }
        catch (AbandonedMutexException)
        {
            canWriteToFile = true;
            mutex.ReleaseMutex();
        }

        IConsoleManager consoleManager = new ConsoleManager();
        IContactList contactList = new ContactList(consoleManager);
        FileHandler fileHandler = new FileHandler(filePath, canWriteToFile);

        UserInterface userInterface = new UserInterface(contactList, fileHandler, consoleManager);
        await userInterface.ProcessUserCommands();

        mutex.ReleaseMutex();
    }
}
