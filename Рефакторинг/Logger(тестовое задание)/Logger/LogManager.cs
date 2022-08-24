namespace Logger
{
    public class LogManager
    {
        public static ILogger GetConsoleLogger()
        {
            return new ConsoleLogger();
        }

        public static ILogger GetFileLogger()
        {
            return new FileLogger();
        }

        public static ILogger GetFileLogger(string logFileDir)
        {
            return new FileLogger(logFileDir);
        }

        public static ILogger GetDataBaseLogger()
        {
            return new DataBaseLogger();
        }

        public static ILogger GetDataBaseLogger(string connectionString)
        {
            return new DataBaseLogger(connectionString);
        }
    }
}
