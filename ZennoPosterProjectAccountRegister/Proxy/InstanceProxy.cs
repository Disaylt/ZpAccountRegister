using NLog;
using SmartProxyV2_ZennoLabVersion.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZennoLab.CommandCenter;
using ZennoPosterProjectAccountRegister.Logger;

namespace ZennoPosterProjectAccountRegister.Proxy
{
    internal class InstanceProxy
    {
        protected ProjectLogger Logger { get; }
        private readonly Instance _instance;

        internal InstanceProxy(Instance instance)
        {
            _instance = instance;
            Logger = new ProjectLogger();
        }

        internal void SetProxy(ProxyModel proxyModel)
        {
            string proxy = $"http://{proxyModel.User}:{proxyModel.Password}@{proxyModel.Ip}:{proxyModel.PortData.PortNum}";
            _instance.SetProxy(proxy,
                true,
                true,
                true,
                true);
            Logger.Info($"Set proxy {proxy}");
        }
    }
}
