﻿namespace Logger
{
    public interface ILogger
    {
        void Info(string msg);

        void Warn(string msg);

        void Debug(string msg);

        void Error(string msg);
    }
}
