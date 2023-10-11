using System;
using System.IO;
using System.Threading;

using HwCreateGame;

public class Program
{
    public static void Main(string[] args)
    {
        string filePath = "contacts.txt";
        bool canWriteToFile = false;
        Mutex mutex = new Mutex(false, "ContactsFileLock"); // Создаем Mutex

        // Пытаемся захватить Mutex
        try
        {
            if (mutex.WaitOne(TimeSpan.Zero, true))
            {
                canWriteToFile = true; // Разрешаем запись в файл
            }
            else
            {
                Console.WriteLine("Доступ к файлу заблокирован. Разрешена только операция чтения.");
            }
        }
        catch (AbandonedMutexException)
        {
            canWriteToFile = true; // Если Mutex был заброшен, разрешаем запись в файл
        }

        ContactList contactList = new ContactList();
        FileHandler fileHandler = new FileHandler(filePath);

        // Запускаем пользовательский интерфейс
        UserInterface userInterface = new UserInterface(contactList, fileHandler, canWriteToFile);
        userInterface.ProcessUserCommands();

        // Записываем контакты в файл перед выходом
        fileHandler.WriteContactsToFile(contactList.GetAllContacts());

        // Освобождаем Mutex
        mutex.ReleaseMutex();
    }
}
