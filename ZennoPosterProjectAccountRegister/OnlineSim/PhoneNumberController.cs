﻿using Global.ZennoLab.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZennoPosterProjectAccountRegister.Models.Json.OnlineSim;

namespace ZennoPosterProjectAccountRegister.OnlineSim
{
    internal class PhoneNumberController : OnlineSimTzHandler, IPhoneNumberActions
    {
        public string PhoneNumber { get; }
        public PhoneNumberController(string serviceName) : base(serviceName)
        {
            PhoneNumber = GetPhoneDataAsync()
                .Result
                .Number;
        }

        public async Task<PhoneModel> GetPhoneDataAsync()
        {
            var responseContent = await OnlineSimHttpRequest.RequestForGetNumberDataAsync();
            var pgones = JToken.Parse(responseContent).ToObject<List<PhoneModel>>();
            PhoneModel phone = JToken.Parse(responseContent).ToObject<List<PhoneModel>>()
                .FirstOrDefault(x => x.TzId == TzId);

            string content = File.ReadAllText("json.txt");
            int tzid = 64138124;
            var phoneList = JToken.Parse(content).ToObject<List<PhoneModel>>();

            return phone;
        }
    }
}
