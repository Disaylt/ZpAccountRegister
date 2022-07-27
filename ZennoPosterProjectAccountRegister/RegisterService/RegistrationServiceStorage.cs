﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZennoPosterProjectAccountRegister.RegisterService
{
    internal class RegistrationServiceStorage
    {
        private readonly Dictionary<string, CreateRegisterContoller> _controllers;
        public RegistrationServiceStorage(RegistrationServices registrationServices)
        {
            _controllers = registrationServices.Services;
        }

        public RegisterController GetRegistrationController(string nameService)
        {
            if(_controllers.ContainsKey(nameService))
            {
                return _controllers[nameService].Invoke();
            }
            else
            {
                return default;
            }
        }
    }
}