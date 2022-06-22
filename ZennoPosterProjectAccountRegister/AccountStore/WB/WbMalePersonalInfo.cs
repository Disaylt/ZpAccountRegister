using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZennoPosterProjectAccountRegister.AccountStore;

namespace ZennoPosterProjectAccountRegister.AccountStore.WB
{
    class WbMalePersonalInfo : PersonalInfoLoader
    {
        private const string _firstNameFilePath = "MaleFirstName.txt";
        private const string _lastNameFilePath = "MaleLastName.txt";
        private const string _middleNameFilePath = "";

        internal WbMalePersonalInfo() : base(_firstNameFilePath, _lastNameFilePath, _middleNameFilePath)
        {
        }
    }
}
