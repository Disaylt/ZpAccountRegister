using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZennoPosterProjectAccountRegister.Models.Json.OnlineSim;

namespace ZennoPosterProjectAccountRegister.OnlineSim
{
    internal interface IPhoneNumberActions
    {
        string PhoneNumber { get; }
        Task<PhoneModel> GetPhoneDataAsync();
        Task<bool> CloseNumberAsync();
        int GetSumAvailableNumbers(string serviceName);
    }
}
