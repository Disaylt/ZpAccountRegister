using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZennoPosterProjectAccountRegister.AccountStore.General
{
    internal class GeneralFemalePersonalInfo : PersonalInfoLoader
    {
        private const string _firstNameFilePath = "FemaleFirstName.txt";
        private const string _lastNameFilePath = "FemaleLastName.txt";
        private const string _middleNameFilePath = "";

        internal GeneralFemalePersonalInfo() : base(_firstNameFilePath, _lastNameFilePath, _middleNameFilePath)
        {
        }
    }
}
