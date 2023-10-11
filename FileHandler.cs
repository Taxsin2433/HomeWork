using HwCreateGame;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;

namespace HwCreateGame
{
    public class FileHandler
    {
        private string filePath;
        private Mutex mutex;

        public FileHandler(string filePath)
        {
            this.filePath = filePath;
            mutex = new Mutex();
        }

        // Запись контактов в файл
        public void WriteContactsToFile(List<Contact> contacts)
        {
            mutex.WaitOne();
            try
            {
                using (StreamWriter writer = new StreamWriter(filePath))
                {
                    foreach (Contact contact in contacts)
                    {
                        writer.WriteLine($"{contact.Name},{contact.Surname},{contact.Phone}");
                    }
                }
            }
            finally
            {
                mutex.ReleaseMutex();
            }
        }

        // Чтение контактов из файла
        public List<Contact> ReadContactsFromFile()
        {
            List<Contact> contacts = new List<Contact>();

            using (StreamReader reader = new StreamReader(filePath))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] contactData = line.Split(',');
                    if (contactData.Length == 3)
                    {
                        Contact contact = new Contact(contactData[0], contactData[1], contactData[2]);
                        contacts.Add(contact);
                    }
                }
            }

            return contacts;
        }
    }
}

