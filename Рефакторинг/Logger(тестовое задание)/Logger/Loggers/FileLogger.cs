using System;
using System.IO;
using System.Text;

namespace Logger
{
    class FileLogger : Logger
    {
        private readonly string _LOGS_DIRECTORY;
        private readonly string _LOG_FILENAME = $"Log_{DateTime.Now.ToString("d")}.txt";

        private object _lockObj = new object();

        public FileLogger()
        {
            _LOGS_DIRECTORY = "logs";
            CreateDirectory();
        }

        public FileLogger(string logsDirectory)
        {
            _LOGS_DIRECTORY = logsDirectory;
            CreateDirectory();
        }

        protected override void Log(string msg)
        {
            lock (_lockObj)
            {
                using (StreamWriter writer = new StreamWriter(Path.Combine(_LOGS_DIRECTORY, _LOG_FILENAME), true, Encoding.Default))
                {
                    writer.WriteLine(msg);
                }
            }
        }

        private void CreateDirectory()
        {
            if (!Directory.Exists(_LOGS_DIRECTORY))
                Directory.CreateDirectory(_LOGS_DIRECTORY);
        }
    }
}
