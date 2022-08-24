using Logger;
using System;

namespace Logger_Maticson
{
    class Program
    {
        public static ILogger Logger;

        static void Main(string[] args)
        {
            Logger = LogManager.GetConsoleLogger();
            Logger.Info("Логирование в консоли");
            Logger.Debug("Логирование в консоли");
            Logger.Warn("Логирование в консоли");
            Logger.Error("Логирование в консоли");

            Logger = LogManager.GetFileLogger();
            Logger.Info("Лог в файл");
            Logger.Debug("Лог в файл");
            Logger.Warn("Лог в файл");
            Logger.Error("Лог в файл");

            Logger = LogManager.GetFileLogger("myPath");
            Logger.Info("Лог в файл по указанному пути");
            Logger.Debug("Лог в файл по указанному пути");
            Logger.Warn("Лог в файл по указанному пути");
            Logger.Error("Лог в файл по указанному пути");

            Logger = LogManager.GetDataBaseLogger("myConnectionString");
            Logger.Info("Лог в БД");
            Logger.Debug("Лог в БД");
            Logger.Warn("Лог в БД");
            Logger.Error("Лог в БД");

            Console.ReadKey();
        }
    }
}
