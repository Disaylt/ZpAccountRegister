using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZennoPosterProjectAccountRegister.AccountStore
{
    public class GenderOptions
    {
        private readonly Dictionary<string, IPersonalInfo> _genderPersonalInfo;
        public GenderOptions(Dictionary<string, IPersonalInfo> genderPersonalInfo)
        {
            _genderPersonalInfo = genderPersonalInfo;
        }

        public IPersonalInfo GetGenderPersonalInfo(string gender)
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
