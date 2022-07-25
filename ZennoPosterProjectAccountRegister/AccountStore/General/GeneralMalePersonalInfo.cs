using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZennoPosterProjectAccountRegister.AccountStore.General
{
    internal class GeneralMalePersonalInfo : PersonalInfoLoader
    {
        private const string _firstNameFileName = "MaleFirstName.txt";
        private const string _lastNameFileName = "MaleLastName.txt";
        private const string _middleNameFileName = "";

        internal GeneralMalePersonalInfo() : base(_firstNameFileName, _lastNameFileName, _middleNameFileName)
        {
        }
    }
}
