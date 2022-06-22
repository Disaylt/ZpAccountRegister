using SmartProxyV2_ZennoLabVersion.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZennoLab.CommandCenter;

namespace ZennoPosterProjectAccountRegister.Proxy
{
    internal class InstanceProxy
    {
        private readonly Instance _instance;
        internal InstanceProxy(Instance instance)
        {
            _instance = instance;
        }

        internal void SetProxy(ProxyModel proxyModel)
        {
            string proxy = $"http://{proxyModel.User}:{proxyModel.Password}@{proxyModel.Ip}:{proxyModel.PortData.PortNum}";
            _instance.SetProxy(proxy,
                true,
                true,
                true,
                true);
        }
    }
}
