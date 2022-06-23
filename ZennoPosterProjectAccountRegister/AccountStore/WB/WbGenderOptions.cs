using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZennoPosterProjectAccountRegister.AccountStore.WB
{
    public class WbGenderOptions : GenderOptions
    {
        private static Dictionary<string, IPersonalInfo> genderPersonalInfo = new Dictionary<string, IPersonalInfo>
            {
                {"male", new WbMalePersonalInfo() },
                {"female", new WbFemalePersonalInfo() }
            };

        public WbGenderOptions() : base(genderPersonalInfo)
        {

        }
    }
}
