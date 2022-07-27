using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZennoPosterProjectAccountRegister.AccountStore;
using ZennoPosterProjectAccountRegister.OnlineSim;
using ZennoPosterProjectAccountRegister.OnlineSim.WB;

namespace ZennoPosterProjectAccountRegister.RegisterService.OptionBuilders
{
    internal class WbRegisterOptions : GeneralRegisterOptions
    {
        public IPhoneNumberActions PhoneNumberActions { get; }

        public WbRegisterOptions()
        {
            PhoneNumberActions = new WbPhoneNumber();
        }
    }
}
