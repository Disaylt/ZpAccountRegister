using SmartProxyV2_ZennoLabVersion.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZennoLab.InterfacesLibrary.ProjectModel;
using ZennoPosterProjectAccountRegister.AccountStore;
using ZennoPosterProjectAccountRegister.Http;
using ZennoPosterProjectAccountRegister.Http.WB;
using ZennoPosterProjectAccountRegister.Models.Json.WB;

namespace ZennoPosterProjectAccountRegister.WB
{
    internal class WebWbAccount
    {
        private readonly WbAccountHttpSender _httpRegisterChecker;
        public WebWbAccount(ProxyModel proxy, IZennoPosterProjectModel project)
        {
            _httpRegisterChecker = new WbAccountHttpSender(proxy, project);
        }

        public bool CompareAccountData(Account account)
        {
            WbProfile accountData = _httpRegisterChecker.GetPersonalData();
            if(accountData != null
                && accountData.IsAuthenticated
                && accountData.FirstName == account.FirstName
                && accountData.LastName == account.LastName)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public WbAccountSettingsDataModel GetAccountSettings()
        {
            WbAccountSettingsDataModel wbAccountSettingsData = _httpRegisterChecker.GetAccountSettins();
            return wbAccountSettingsData;
        }
    }
}
