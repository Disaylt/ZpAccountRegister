using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartProxyV2_ZennoLabVersion;
using SmartProxyV2_ZennoLabVersion.Models;

namespace ZennoPosterProjectAccountRegister.Proxy
{
    internal class RussianAcountProxy : IAccountProxy
    {
        public ProxyModel Proxy { get; }

        internal RussianAcountProxy()
        {
            Proxy = SmartProxyHandler.GetRussianProxyAsync().Result;
        }

        internal async Task EndProxyWork()
        {
            ProxyPort proxyPort = new ProxyPort(Proxy.PortData.Type, Proxy.PortData.PortNum);
            await SmartProxyHandler.OpenPortAsync(proxyPort);
        }

        public void Dispose()
        {
            EndProxyWork().Wait();
        }
    }
}
