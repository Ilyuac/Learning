using System;

namespace Logger
{
    class Program
    {
        static void Main(string[] args)
        {
            Logger logger = new Logger();

            logger.Debug("Test debug message.");
            logger.DebugFormat("Test debug message.", args);
            logger.Error(new Exception("Test error message."));
            logger.ErrorUnique("Test error message.", new Exception("Test error message."));
            logger.ErrorUnique("Test error message.", new Exception("Test error message."));
            logger.Info("Test info message.");
            logger.SystemInfo("Test system message.");
            logger.Warning("Test warning message.");
        }
    }
}
