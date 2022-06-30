using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZennoPosterProjectAccountRegister.RegisterService
{
    abstract internal class RegistrationServices
    {
        public abstract Dictionary<string, RegisterController> Services { get;}
    }
}
