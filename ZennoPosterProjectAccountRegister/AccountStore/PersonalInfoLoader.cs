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

        internal PersonalInfoLoader(string firstNameFileName, string lastNameFileName, string middleNameFileName)
        {
            FirstNames = LoadPersonalInfo(firstNameFileName);
            LastNames = LoadPersonalInfo(lastNameFileName);
            MiddleNames = LoadPersonalInfo(middleNameFileName);
        }

        private string[] LoadPersonalInfo(string fileName)
        {
            try
            {
                string[] personalInfo = File.ReadAllLines($@"{Project.ProjectFolder}\{fileName}");
                return personalInfo;
            }
            catch
            {
                return new string[0];
            }
        }
    }
}
