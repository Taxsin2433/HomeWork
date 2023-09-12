using System.IO;
using System.Text;
using Newtonsoft.Json;
namespace HwCreateGame.Logger
{
    public class JsonFileAppender
    {
        private string filePath;
        public JsonFileAppender(string filePath)
        {
            this.filePath = filePath;
        }

 

        public void Append(Result result)
        {
            string json = JsonConvert.SerializeObject(result);
            byte[] byteContent = Encoding.UTF8.GetBytes(json);

            lock (filePath)
            {
                using (FileStream fs = new FileStream(filePath, FileMode.Append, FileAccess.Write, FileShare.Read))
                {
                    fs.Write(byteContent, 0, byteContent.Length);
                }
            }
        }
    }
}