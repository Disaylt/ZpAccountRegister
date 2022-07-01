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
            if(!Directory.Exists(_logFolderName))
            {
                Directory.CreateDirectory(_logFolderName);
            }
        }

        public void Info(string message)
        {

            string[] logMessage = new string[] { $"{DateTime.Now} | {Configuration.Settings.SessionName} | INFO | {message}\r\n" };
            WriteLogMessage(logMessage);
        }
        public void Error(Exception exception)
        {
            string[] logMeesage = new string[]
            {
                $"{DateTime.Now} | {Configuration.Settings.SessionName} | ERROR | {exception.Message}",
                $"{exception.StackTrace}\r\n"
            };
            WriteLogMessage(logMeesage);
        }

        public void Error(Exception exception, string message)
        {
            string[] logMeesage = new string[]
            {
                $"{DateTime.Now} | {Configuration.Settings.SessionName} | ERROR | {message}",
                $"{exception.Message}",
                $"{exception.StackTrace}\r\n"
            };
            WriteLogMessage(logMeesage);
        }

        private void WriteLogMessage(string[] lineMessage)
        {
            string filePath = GetLogFileName();
            File.AppendAllLines(filePath, lineMessage);
        }

        private string GetLogFileName()
        {
            if(string.IsNullOrEmpty(Configuration.Settings.SessionName))
            {
                return $@"{_logFolderName}\GeneralLog.log";
            }
            else
            {
                return $@"{_logFolderName}\{Configuration.Settings.SessionName}.log";
            }
        }
    }
}
