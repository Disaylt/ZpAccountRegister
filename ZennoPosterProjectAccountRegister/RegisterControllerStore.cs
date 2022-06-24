using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZennoPosterProjectAccountRegister.WB;

namespace ZennoPosterProjectAccountRegister
{
    internal class RegisterControllerStore
    {
        private static Dictionary<string, RegisterController> _registerControllerStore;

        public RegisterControllerStore()
        {
            if(_registerControllerStore == null)
            {
                _registerControllerStore = CreateDefaultRegisterControllers();
            }
        }

        public void InsertNewService(string service, RegisterController registerController)
        {
            if(!_registerControllerStore.ContainsKey(service))
            {
                _registerControllerStore.Add(service, registerController);
            }
            else
            {
                throw new Exception("Register controller already exists");
            }
        }

        public RegisterController GetRegisterController(string service)
        {
            if(_registerControllerStore.ContainsKey(service))
            {
                return _registerControllerStore[service];
            }
            else
            {
                throw new Exception("Register controller not found");
            }
        }

        private Dictionary<string, RegisterController> CreateDefaultRegisterControllers()
        {
            Dictionary<string, RegisterController> registerControllerStore = new Dictionary<string, RegisterController>
            {
                {"wb", new WbRegister() }
            };
            return registerControllerStore;
        }
    }
}
