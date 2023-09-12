using HwCreateGame.HwCreateGame.Logger;
using System;
namespace HwCreateGame.Logger
{
    public class Logger
    {
        private static Logger instance;
        private LogLevel logLevel;
        private JsonFileAppender fileAppender;
        private Logger()
        {
            fileAppender = new JsonFileAppender("log.json");
        }

        public static Logger Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Logger();
                }
                return instance;
            }
        }

        public void SetLogLevel(LogLevel level)
        {
            logLevel = level;
        }

        public void Log(Result result)
        {
            if (result.Status <= logLevel)
            {
                Console.WriteLine($"{result.DateTime}: {result.Status}: {result.Message}");
                fileAppender.Append(result);
            }
        }
    }
}

