using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZennoPosterProjectAccountRegister.AccountStore
{
    class PersonalInfoLoader : IPersonalInfo
    {
        public string[] FirstNames { get; }
        public string[] LastNames { get; }
        public string[] MiddleNames { get; }

        internal PersonalInfoLoader(string firstNameFilePath, string lastNameFilePath, string middleNameFilePath)
        {
            FirstNames = LoadPersonalInfo(firstNameFilePath);
            LastNames = LoadPersonalInfo(lastNameFilePath);
            MiddleNames = LoadPersonalInfo(middleNameFilePath);
        }

        private string[] LoadPersonalInfo(string filePath)
        {
            try
            {
                string[] personalInfo = File.ReadAllLines(filePath);
                return personalInfo;
            }
            catch
            {
                return new string[0];
            }
        }
    }
}
