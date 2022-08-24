using System;

namespace Logger
{
    class ConsoleLogger : Logger
    {
        protected override void Log(string msg)
        {
            Console.WriteLine(msg);
        }
    }
}
