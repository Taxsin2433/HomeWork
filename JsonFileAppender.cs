using System.IO;
using System.Text;
using Newtonsoft.Json;
using System.Linq;

namespace HwCreateGame.Logger
{
    public class JsonFileAppender
    {
        private string directoryPath;
        private const int MaxFileCount = 3;

        public JsonFileAppender(string directoryPath)
        {
            this.directoryPath = directoryPath;
            CreateDirectoryIfNotExists();
        }

        public void Append(Result result)
        {
            string fileName = GetFileName();
            string filePath = Path.Combine(directoryPath, fileName);

            string json = JsonConvert.SerializeObject(result);
            byte[] byteContent = Encoding.UTF8.GetBytes(json);

            lock (filePath)
            {
                using (FileStream fs = new FileStream(filePath, FileMode.Append, FileAccess.Write, FileShare.Read))
                {
                    fs.Write(byteContent, 0, byteContent.Length);
                }
            }

            CleanupOldFiles();
        }

        private string GetFileName()
        {
            string timestamp = DateTime.Now.ToString("yyyyMMddHHmmssfff");
            return $"log_{timestamp}.json";
        }

        private void CleanupOldFiles()
        {
            string[] files = Directory.GetFiles(directoryPath, "log_*.json")
                                      .OrderByDescending(f => File.GetCreationTime(f))
                                      .Skip(MaxFileCount)
                                      .ToArray();

            foreach (string file in files)
            {
                File.Delete(file);
            }
        }

        private void CreateDirectoryIfNotExists()
        {
            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }
        }
    }
}






//using System.IO;
//using System.Text;
//using Newtonsoft.Json;
//namespace HwCreateGame.Logger
//{
//    public class JsonFileAppender
//    {
//        private string filePath;
//        public JsonFileAppender(string filePath)
//        {
//            this.filePath = filePath;
//        }



//        public void Append(Result result)
//        {
//            string json = JsonConvert.SerializeObject(result);
//            byte[] byteContent = Encoding.UTF8.GetBytes(json);

//            lock (filePath)
//            {
//                using (FileStream fs = new FileStream(filePath, FileMode.Append, FileAccess.Write, FileShare.Read))
//                {
//                    fs.Write(byteContent, 0, byteContent.Length);
//                }
//            }
//        }
//    }
//}



