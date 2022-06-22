using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZennoPosterProjectAccountRegister.Models.Json.OnlineSim;
using Newtonsoft.Json.Linq;

namespace ZennoPosterProjectAccountRegister.OnlineSim
{
    internal class WbPhoneNumber : OnlineSimTzHandler, IPhoneNumberActions
    {
        private const string _serviceName = "Wildberries";
        public WbPhoneNumber() : base(_serviceName)
        {

        }

        public async Task<PhoneModel> GetPhoneDataAsync()
        {
            var responseContent = await OnlineSimHttpRequest.RequestForGetNumberDataAsync();
            PhoneModel phone = JToken.Parse(responseContent).ToObject<List<PhoneModel>>()
                .FirstOrDefault(x=> x.TzId == TzId);
            return phone;
        }
    }
}
