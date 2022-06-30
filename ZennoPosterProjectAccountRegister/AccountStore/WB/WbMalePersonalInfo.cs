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
        private const string _firstNameFileName = "MaleFirstName.txt";
        private const string _lastNameFileName = "MaleLastName.txt";
        private const string _middleNameFileName = "";

        internal WbMalePersonalInfo() : base(_firstNameFileName, _lastNameFileName, _middleNameFileName)
        {
        }
    }
}
