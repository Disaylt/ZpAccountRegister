using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZennoPosterProjectAccountRegister.AccountStore.General;

namespace ZennoPosterProjectAccountRegister.AccountStore.Letu
{
    internal class LetuGenderOptions : GenderOptions
    {
        private static Dictionary<string, IPersonalInfo> _genderPersonalInfo = new Dictionary<string, IPersonalInfo>
        {
            {"male", new GeneralMalePersonalInfo() },
            {"female", new GeneralFemalePersonalInfo() }
        };

        public LetuGenderOptions() : base(_genderPersonalInfo)
        {

        }
    }
}
