using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using ZennoPosterProjectAccountRegister.Models.Json.OnlineSim;

namespace ZennoPosterProjectAccountRegister.OnlineSim
{
    internal class OnlineSimTzHandler : OnlineSimSettings
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
                TzModel tzModel = await OnlineSimHttpRequest.RequestForClosePhoneNumberAsync(TzId);
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
            TzModel tzModel = await OnlineSimHttpRequest.RequestForGetTzIdAsync(serviceName);
            if (tzModel != null && tzModel.ResponseCode == 1)
            {
                Thread.Sleep(5 * 1000); //await registration tzId 
                return tzModel.Id;
            }
            else
            {
                return default;
            }
        }
    }
}
