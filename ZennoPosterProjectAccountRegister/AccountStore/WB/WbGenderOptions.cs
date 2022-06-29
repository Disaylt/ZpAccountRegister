using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZennoPosterProjectAccountRegister.AccountStore.WB
{
    public class WbGenderOptions : GenderOptions
    {
        private readonly static Dictionary<string, IPersonalInfo> _genderPersonalInfo = new Dictionary<string, IPersonalInfo>
            {
                {"male", new WbMalePersonalInfo() },
                {"female", new WbFemalePersonalInfo() }
            };

        public WbGenderOptions() : base(_genderPersonalInfo)
        {

        }
    }
}
