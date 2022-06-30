using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZennoPosterProjectAccountRegister.RegisterService
{
    internal class RegistrationService
    {
        private readonly Dictionary<string, RegisterController> _controllers;
        public RegistrationService(RegistrationServices registrationServices)
        {
            _controllers = registrationServices.Services;
        }

        public RegisterController GetRegistrationController(string nameService)
        {
            if(_controllers.ContainsKey(nameService))
            {
                return _controllers[nameService];
            }
            else
            {
                return default;
            }
        }
    }
}
