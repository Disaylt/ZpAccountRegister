using SmartProxyV2_ZennoLabVersion;
using SmartProxyV2_ZennoLabVersion.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZennoPosterProjectAccountRegister.Tests.Proxy
{
    internal class TestProxy
    {
        public static ProxyModel GetTestProxy()
        {
            ProxyModel proxyModel = new ProxyModel("log", "pass", "proxy.soax.com");
            ProxyPort port = new ProxyPort("wb", 9000);
            proxyModel.PortData = port;
            return proxyModel;
        }
    }
}
