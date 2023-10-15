namespace HwCreateGame
{
    public class FileHandler
    {
        private readonly string filePath;

        public FileHandler(string filePath)
        {
            this.filePath = filePath;
        }

        public async Task WriteContactsToFileAsync(List<Contact> contacts)
        {
            using (var writer = new StreamWriter(filePath))
            {
                foreach (var contact in contacts)
                {
                    await writer.WriteLineAsync($"{contact.Name},{contact.Surname},{contact.Phone}");
                }
            }
        }

        public List<Contact> ReadContactsFromFile()
        {
            var contacts = new List<Contact>();

            using (var reader = new StreamReader(filePath))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    var contactData = line.Split(',');
                    if (contactData.Length == 3)
                    {
                        var contact = new Contact(contactData[0], contactData[1], contactData[2]);
                        contacts.Add(contact);
                    }
                }
            }

            return contacts;
        }
    }
}
