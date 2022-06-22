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
        Task<PhoneModel> GetPhoneDataAsync();
        Task<bool> CloseNumberAsync();
    }
}
