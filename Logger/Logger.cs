using System;
using System.Collections.Generic;
using System.IO;

namespace Logger
{
    internal class Logger : ILog
    {
        private List<string> unique = new List<string>();

        public void Debug(string message)
        {
            Write("Debug.log", GenerateMessageString(message, Exceptions.Debug));
        }

        public void Debug(string message, Exception e)
        {
            Write("Debug.log", GenerateMessageString(message, Exceptions.Debug, e));
        }

        public void DebugFormat(string message, params object[] args)
        {
            Write("Debug.log", GenerateMessageString(message, Exceptions.DebugFormat, args));
        }

        public void Error(string message)
        {
            Write("Error.log", GenerateMessageString(message, Exceptions.Error));
        }

        public void Error(string message, Exception e)
        {
            Write("Error.log", GenerateMessageString(message, Exceptions.Error, e));
        }

        public void Error(Exception ex)
        {
            Write("Error.log", GenerateMessageString(Exceptions.Error, ex));
        }

        public void ErrorUnique(string message, Exception e)
        {
            var str = GenerateMessageString(message, Exceptions.ErrorUnique, e);

            if (!unique.Contains(str))
            {
                unique.Add(str);
                Write("Error.log", str);
            }
        }

        public void Fatal(string message)
        {
            Write("Fatal.log", GenerateMessageString(message, Exceptions.Fatal));
        }

        public void Fatal(string message, Exception e)
        {
            Write("Fatal.log", GenerateMessageString(message, Exceptions.Fatal, e));
        }

        public void Info(string message)
        {
            Write("Info.log", GenerateMessageString(message, Exceptions.Information));
        }

        public void Info(string message, Exception e)
        {
            Write("Info.log", GenerateMessageString(message, Exceptions.Information, e));
        }

        public void Info(string message, params object[] args)
        {
            Write("Info.log", GenerateMessageString(message, Exceptions.Information, args));
        }

        public void SystemInfo(string message, Dictionary<object, object> properties = null)
        {
            Write("Info.log", GenerateMessageString(message, Exceptions.SystemInfo, properties));
        }

        public void Warning(string message)
        {
            Write("Warning.log", GenerateMessageString(message, Exceptions.Warrning));
        }

        public void Warning(string message, Exception e)
        {
            Write("Warning.log", GenerateMessageString(message, Exceptions.Warrning, e));
        }

        public void WarningUnique(string message)
        {
            var str = GenerateMessageString(message, Exceptions.WarningUnique);

            if (!unique.Contains(str))
            {
                unique.Add(str);
                Write("Warning.log", str);
            }
        }

        private string GenerateMessageString(string message, Exceptions exceptions)
        {
            return $"{DateTime.Now.ToString("hh:mm:ss")} {exceptions}: {message}";
        }

        private string GenerateMessageString(string message, Exceptions exceptions, Exception exception = null)
        {
            return $"{DateTime.Now.ToString("hh:mm:ss")} {exceptions}: {message}\n {exception.StackTrace}";
        }

        private string GenerateMessageString(Exceptions exceptions, Exception exception)
        {
            return $"{DateTime.Now.ToString("hh:mm:ss")} {exceptions}: {exception.Message}\n {exception.StackTrace}";
        }

        private string GenerateMessageString(string message, Exceptions exceptions, params object[] obj)
        {
            return $"{DateTime.Now.ToString("hh:mm:ss")} {exceptions}: {message}\n";
        }

        private void Write(string file, string message)
        {

            string path = $@".\{DateTime.Now.ToString("yyyy-MM-dd")}";

            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
                
            }

            path += @"\" + file;

            using (var streamWriter = new StreamWriter(path, true))
            {
                streamWriter.WriteLine(message);
            }
        }
    }
}
