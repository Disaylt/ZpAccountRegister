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
                if(tzModel != null)
                {
                    if (tzModel.ResponseCode == "1")
                    {
                        return true;
                    }
                    else if (tzModel.ResponseCode == "NO_COMPLETE_TZID")
                    {
                        await AwaitWorkNumberAsync();
                        await OnlineSimHttpRequest.RequestForClosePhoneNumberAsync(TzId);
                        if (tzModel.ResponseCode == "1")
                        {
                            return true;
                        }
                    }
                }
            }
            catch
            {
                return false;
            }
            return false;
        }

        private async Task AwaitWorkNumberAsync()
        {
            var numbers = await OnlineSimHttpRequest.RequestForGetNumberDataAsync();
            int workPhoneTimer = numbers.FirstOrDefault(x => x.TzId == TzId).Time;
            int awaitTimer = workPhoneTimer - 860; //время жизни номера 900 сек, выключить можно только через с начала использования 30 сек + 10 сек запаса.
            if (awaitTimer > 0)
            {
                Thread.Sleep(1000 * awaitTimer);
            }

        }

        private async Task<int> GetTzIdAsync(string serviceName)
        {
            TzModel tzModel = await OnlineSimHttpRequest.RequestForGetTzIdAsync(serviceName);
            if (tzModel != null && tzModel.ResponseCode == "1")
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
