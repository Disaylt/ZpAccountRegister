using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZennoPosterProjectAccountRegister.AccountStore;

namespace ZennoPosterProjectAccountRegister.AccountStore.WB
{
    class WbFemalePersonalInfo : PersonalInfoLoader
    {
        private const string _firstNameFilePath = "FemaleFirstName.txt";
        private const string _lastNameFilePath = "FemaleLastName.txt";
        private const string _middleNameFilePath = "";

        internal WbFemalePersonalInfo() : base(_firstNameFilePath, _lastNameFilePath, _middleNameFilePath)
        {
        }
    }
}
