using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZennoPosterProjectAccountRegister.AccountStore
{
    internal class GenderOptions
    {
        private readonly Dictionary<string, IPersonalInfo> _genderPersonalInfo;
        internal GenderOptions(Dictionary<string, IPersonalInfo> genderPersonalInfo)
        {
            _genderPersonalInfo = genderPersonalInfo;
        }

        internal IPersonalInfo GetGenderPersonalInfo(string gender)
        {
            if(_genderPersonalInfo.ContainsKey(gender))
            {
                return _genderPersonalInfo[gender];
            }
            else
            {
                return default;
            }
        }
    }
}
