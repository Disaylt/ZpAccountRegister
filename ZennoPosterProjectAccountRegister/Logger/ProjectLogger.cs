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
        private const string _logPath = @"\logs";

        public ProjectLogger()
        {
            if(!Directory.Exists(_logPath))
            {
                Directory.CreateDirectory(_logPath);
            }
        }

        public void Info(string message)
        {

            string[] logMessage = new string[] { $"{DateTime.Now} | {Project.Settings.SessionName} | INFO | {message}\r\n" };
            WriteLogMessage(logMessage);
        }
        public void Error(Exception exception)
        {
            string[] logMeesage = new string[]
            {
                $"{DateTime.Now} | {Project.Settings.SessionName} | ERROR | {exception.Message}\r\n",
                $"{exception.StackTrace}\r\n"
            };
            WriteLogMessage(logMeesage);
        }

        public void Error(Exception exception, string message)
        {
            string[] logMeesage = new string[]
            {
                $"{DateTime.Now} | {Project.Settings.SessionName} | ERROR | {message}\r\n",
                $"{exception.Message}\r\n",
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
            if(string.IsNullOrEmpty(Project.Settings.SessionName))
            {
                return $@"{_logPath}\GeneralLog.log";
            }
            else
            {
                return $@"{_logPath}\{Project.Settings.SessionName}.log";
            }
        }
    }
}
