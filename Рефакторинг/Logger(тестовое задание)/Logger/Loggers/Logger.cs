using System;

namespace Logger
{
    abstract class Logger : ILogger
    {
        //стандартные выводы лога для всех логгеров. В методе Log - реализация логирования конкретным логгером
        public void Info(string msg)
        {
            Log($"{DateTime.Now} INFO {msg}");
        }

        public void Warn(string msg)
        {
            Log($"{DateTime.Now} WARN {msg}");
        }

        public void Debug(string msg)
        {
            Log($"{DateTime.Now} DEBUG {msg}");
        }

        public void Error(string msg)
        {
            Log($"{DateTime.Now} ERROR {msg}");
        }

        protected abstract void Log(string msg);
    }
}
