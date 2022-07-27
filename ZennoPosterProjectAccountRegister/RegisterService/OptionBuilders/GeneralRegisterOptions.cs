using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZennoPosterProjectAccountRegister.AccountStore;

namespace ZennoPosterProjectAccountRegister.RegisterService.OptionBuilders
{
    internal class GeneralRegisterOptions : RegisterOptions
    {
        public GeneralRegisterOptions()
        {
            SessionNameBuilder = new SessionNameBuilder(true, true);
        }
    }
}