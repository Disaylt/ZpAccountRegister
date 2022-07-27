using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZennoPosterProjectAccountRegister.Logger
{
    internal class ProjectLogger
    {
        private static object _sync = new object();
        private readonly string _logFileName = "logs";

        public ProjectLogger()
        {

        }

        public ProjectLogger(string logFileName)
        {
            _logFileName = logFileName;
        }

        public void Info(string message)
        {
            string[] logMessage = new string[] { $"{DateTime.Now} | INFO | {message}\r\n" };
            WriteLogMessage(logMessage);
        }
        public void Error(Exception exception)
        {
            string[] logMeesage = new string[]
            {
                $"{DateTime.Now} | ERROR | {exception.Message}",
                $"{exception.StackTrace}\r\n"
            };
            WriteLogMessage(logMeesage);
        }

        public void Error(Exception exception, string message)
        {
            string[] logMeesage = new string[]
            {
                $"{DateTime.Now} | ERROR | {message}",
                $"{exception.Message}",
                $"{exception.StackTrace}\r\n"
            };
            WriteLogMessage(logMeesage);
        }

        private void WriteLogMessage(string[] lineMessage)
        {
            lock(_sync)
            {
                string filePath = $@"{Configuration.ProjectFilesFolder}\{_logFileName}.log";
                File.AppendAllLines(filePath, lineMessage);
            }
        }
    }
}