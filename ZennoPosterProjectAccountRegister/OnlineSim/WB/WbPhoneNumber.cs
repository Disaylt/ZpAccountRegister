﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZennoPosterProjectAccountRegister.Models.Json.OnlineSim;
using Newtonsoft.Json.Linq;

namespace ZennoPosterProjectAccountRegister.OnlineSim.WB
{
    internal class WbPhoneNumber : PhoneNumberController
    {
        private const string _serviceName = "Wildberries";
        public WbPhoneNumber() : base(_serviceName)
        {

        }
    }
}
