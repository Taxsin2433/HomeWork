using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace HwCreateGame
{
    public class FileHandler
    {
        private string _filePath;
        private bool _canWriteToFile;

        public FileHandler(string filePath, bool canWriteToFile)
        {
            _filePath = filePath;
            _canWriteToFile = canWriteToFile;
        }

        public async Task WriteContactsToFileAsync(List<Contact> contacts)
        {
            if (!_canWriteToFile)
            {
                Console.WriteLine("Writing to the file is not allowed in this instance of the application.");
                return;
            }

            try
            {
                string json = JsonConvert.SerializeObject(contacts, Formatting.Indented);
                using (StreamWriter writer = new StreamWriter(_filePath))
                {
                    await writer.WriteAsync(json);
                }
            }
            catch (IOException ex)
            {
                Console.WriteLine($"Error writing to the file: {ex.Message}");
            }
        }

        public async Task<List<Contact>> ReadContactsFromFileAsync()
        {
            List<Contact> contacts = new List<Contact>();

            try
            {
                if (File.Exists(_filePath))
                {
                    using (StreamReader reader = new StreamReader(_filePath))
                    {
                        string json = await reader.ReadToEndAsync();
                        contacts = JsonConvert.DeserializeObject<List<Contact>>(json);
                    }
                }
            }
            catch (IOException ex)
            {
                Console.WriteLine($"Error reading the file: {ex.Message}");
            }

            return contacts;
        }
    }
}
