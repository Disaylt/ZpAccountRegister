using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZennoPosterProjectAccountRegister.AccountStore
{
    interface IPersonalInfo
    {
        string[] FirstNames { get; }
        string[] LastNames { get; }
        string[] MiddleNames { get; }
    }
}
