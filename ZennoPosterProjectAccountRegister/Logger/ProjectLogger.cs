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
        private const string _logFolderName = "logs";

        public ProjectLogger()
        {
            if (!Directory.Exists($@"{Configuration.ProjectFolder}\{_logFolderName}"))
            {
                Directory.CreateDirectory($@"{Configuration.ProjectFolder}\{_logFolderName}");
            }
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
            string filePath = $@"{Configuration.ProjectFolder}\{_logFolderName}\GeneralLog.log";
            File.AppendAllLines(filePath, lineMessage);
        }
    }
}