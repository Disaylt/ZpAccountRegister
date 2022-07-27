using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZennoPosterProjectAccountRegister.AccountStore.General
{
    internal class GeneralGenderOptions : GenderOptions
    {
        private static readonly Dictionary<string, IPersonalInfo> _genderPersonalInfo = new Dictionary<string, IPersonalInfo>
        {
            {"male", new GeneralMalePersonalInfo() },
            {"female", new GeneralFemalePersonalInfo() }
        };

        public GeneralGenderOptions() : base(_genderPersonalInfo)
        {

        }
    }
}
