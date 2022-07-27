using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZennoPosterProjectAccountRegister.AccountStore;

namespace ZennoPosterProjectAccountRegister.RegisterService
{
    internal abstract class RegisterOptions
    {
        public abstract SessionNameBuilder SessionNameBuilder { get; protected set; }
        public abstract Account Account { get; protected set; }
    }
}
