using SmartProxyV2_ZennoLabVersion.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using ZennoLab.InterfacesLibrary.ProjectModel;
using ZennoPosterProjectAccountRegister.Models.Json.WB;

namespace ZennoPosterProjectAccountRegister.Http.WB
{
    internal class WbAccountHttpSender : HttpSenderClient
    {
        public WbAccountHttpSender(ProxyModel proxy, IZennoPosterProjectModel project) : base(project, proxy)
        {

        }

        public WbProfile GetPersonalData()
        {
            WbProfileModel wbProfileModel = SendRequestAsync<WbProfileModel>(HttpMethod.Post, "https://www.wildberries.ru/webapi/personalinfo").Result;
            return wbProfileModel.ProfileData;
        }

        public WbAccountSettingsDataModel GetAccountSettins()
        {
            WbAccountSettingsModel settings = SendRequestAsync<WbAccountSettingsModel>(HttpMethod.Post, "https://www.wildberries.ru/webapi/lk/details/data").Result;
            return settings.Value.Data;
        }
    }
}
