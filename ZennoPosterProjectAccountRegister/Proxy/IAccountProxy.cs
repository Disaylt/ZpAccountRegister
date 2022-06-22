using SmartProxyV2_ZennoLabVersion.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZennoPosterProjectAccountRegister.Proxy
{
    interface IAccountProxy : IDisposable
    {
        ProxyModel Proxy { get; }
    }
}
