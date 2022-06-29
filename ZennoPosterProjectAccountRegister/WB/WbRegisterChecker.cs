using SmartProxyV2_ZennoLabVersion.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZennoLab.InterfacesLibrary.ProjectModel;
using ZennoPosterProjectAccountRegister.AccountStore;
using ZennoPosterProjectAccountRegister.Http;

namespace ZennoPosterProjectAccountRegister.WB
{
    internal class WbRegisterChecker
    {
        private readonly Account _account;
        private readonly HttpSenderClient _httpSenderClient;
        public WbRegisterChecker(Account account, ProxyModel proxy, IZennoPosterProjectModel project)
        {
            _account = account;
            _httpSenderClient = new HttpSenderClient(project, proxy);
        }

        public bool IsRegistred()
        {

        }
    }
}
