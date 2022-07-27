using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZennoPosterProjectAccountRegister.RegisterService.OptionBuilders;

namespace ZennoPosterProjectAccountRegister.RegisterService
{
    internal class RegistrationServiceCollector
    {
        private readonly Dictionary<string, CreateRegisterContoller> _controllers;
        private readonly OptionsCollector _optionsCollector;
        public RegistrationServiceCollector(RegistrationServices registrationServices, OptionsCollector optionsCollector)
        {
            _controllers = registrationServices.Services;
            _optionsCollector = optionsCollector;
        }

        public RegisterController GetRegistrationController(string nameService)
        {
            if(_controllers.ContainsKey(nameService))
            {
                RegisterOptions registerOptions = ChoseRegisterOptions(nameService);
                return _controllers[nameService].Invoke(registerOptions);
            }
            else
            {
                return default;
            }
        }

        private RegisterOptions ChoseRegisterOptions(string nameService)
        {
            if(_optionsCollector.Options.ContainsKey(nameService))
            {
                return _optionsCollector.Options[nameService].Invoke();
            }
            else
            {
                return new GeneralRegisterOptions();
            }
        }
    }
}
