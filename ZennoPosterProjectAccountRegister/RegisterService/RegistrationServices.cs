using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZennoPosterProjectAccountRegister.RegisterService
{
    delegate RegisterController CreateRegisterContoller(RegisterOptions registerOptions);
    abstract internal class RegistrationServices
    {
        public abstract Dictionary<string, CreateRegisterContoller> Services { get;}
    }
}
