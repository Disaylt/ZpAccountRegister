using SmartProxyV2_ZennoLabVersion.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using ZennoLab.InterfacesLibrary.ProjectModel;
using ZennoPosterProjectAccountRegister.Http;
using ZennoPosterProjectAccountRegister.Models.Json.WB;

namespace ZennoPosterProjectAccountRegister.WB.RegisterChecker
{
    internal class HttpRegisterChecker : HttpSenderClient
    {
        public HttpRegisterChecker(ProxyModel proxy, IZennoPosterProjectModel project) : base(project, proxy)
        {

        }

        public async Task<WbProfile> GetProfileInfoAsync()
        {
            WbProfileModel wbProfileModel = await SendRequestAsync<WbProfileModel>(HttpMethod.Post, "https://www.wildberries.ru/webapi/personalinfo");
            return wbProfileModel.ProfileData;
        }
    }
}
