using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using ZennoPosterProjectAccountRegister.Models.Json.OnlineSim;

namespace ZennoPosterProjectAccountRegister.OnlineSim
{
    public class OnlineSimTzHandler : OnlineSimSettings
    {
        protected readonly OnlineSimHttpRequest OnlineSimHttpRequest;
        protected int TzId { get; set; }

        public OnlineSimTzHandler(string serviceName)
        {
            OnlineSimHttpRequest = new OnlineSimHttpRequest(Settings.Token);
            TzId = GetTzIdAsync(serviceName).GetAwaiter().GetResult();
        }

        public async Task<bool> CloseNumberAsync()
        {
            try
            {
                string responseContent = await OnlineSimHttpRequest.RequestForClosePhoneNumberAsync(TzId);
                TzModel tzModel = JToken.Parse(responseContent).ToObject<TzModel>();
                if (tzModel != null && tzModel.ResponseCode == 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }

        private async Task<int> GetTzIdAsync(string serviceName)
        {
            string responseContent = await OnlineSimHttpRequest.RequestForGetTzIdAsync(serviceName);
            TzModel tzModel = JToken.Parse(responseContent).ToObject<TzModel>();
            if(tzModel != null && tzModel.ResponseCode == 1)
            {
                return tzModel.Id;
            }
            else
            {
                return 0;
            }
        }
    }
}
