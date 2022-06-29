using SmartProxyV2_ZennoLabVersion.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZennoLab.InterfacesLibrary.ProjectModel;
using ZennoPosterProjectAccountRegister.Http;

namespace ZennoPosterProjectAccountRegister.WB.RegisterChecker
{
    internal class HttpRegisterChecker : HttpSenderClient
    {
        public HttpRegisterChecker(ProxyModel proxy, IZennoPosterProjectModel project) : base(project, proxy)
        {

        }

        public Task<object> GetProfileInfo()
        {

        }
    }
}
