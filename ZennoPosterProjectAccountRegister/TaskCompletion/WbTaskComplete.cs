using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZennoLab.InterfacesLibrary.ProjectModel.Collections;
using ZennoPosterProjectAccountRegister.AccountStore;
using ZennoPosterProjectAccountRegister.Http;
using ZennoPosterProjectAccountRegister.Models.Bson;
using ZennoPosterProjectAccountRegister.MongoDB.WB;
using ZennoPosterProjectAccountRegister.OnlineSim;
using ZennoPosterProjectAccountRegister.ZennoPoster;

namespace ZennoPosterProjectAccountRegister.TaskCompletion
{
    internal class WbTaskComplete : ITaskComplete
    {
        private readonly ZennoProfile _zennoProfile;
        private readonly Account _account;
        private readonly IProfile _profile;
        private readonly IPhoneNumberActions _phoneNumberActions;
        private readonly Configuration _configuration;
        public WbTaskComplete(ZennoProfile zennoProfile, Account account, IProfile profile, IPhoneNumberActions phoneNumber)
        {
            _configuration = Configuration.Instance;
            _profile = profile;
            _zennoProfile = zennoProfile;
            _account = account;
            _phoneNumberActions = phoneNumber;
        }

        public void BadEnd()
        {
            string pathBadAccounts = _configuration.GetAccountsRouteForCurrentSeller().PathForSaveBadAccount;
            _zennoProfile.SaveProfile(pathBadAccounts);
            AccountDbModel accountDb = CreateAccountDbData(false, false);
            WbBuyoutsShopMongoAccounts<AccountDbModel> wbBuyoutsShopMongo = new WbBuyoutsShopMongoAccounts<AccountDbModel>("badAccounts");
            wbBuyoutsShopMongo.Insert(accountDb);
        }

        public void GoodEnd()
        {
            string pathGoodAccounts = _configuration.GetAccountsRouteForCurrentSeller().PathForSaveGoodAccount;
            _zennoProfile.SaveProfile(pathGoodAccounts);
            AccountDbModel accountDb = CreateAccountDbData(true, false);
            WbBuyoutsShopMongoAccounts<AccountDbModel> wbBuyoutsShopMongo = new WbBuyoutsShopMongoAccounts<AccountDbModel>("accounts");
            wbBuyoutsShopMongo.Insert(accountDb);
        }

        private AccountDbModel CreateAccountDbData(bool isActive, bool inWork)
        {
            ZennoCookieContainer zennoCookieContainer = new ZennoCookieContainer(_profile.CookieContainer);
            string jsonCookies = zennoCookieContainer.ConvertToJsonString();
            AccountDbModel accountDbModel = new AccountDbModel
            {
                Cookies = jsonCookies,
                IsActive = isActive,
                InWork = inWork,
                CreateDate = DateTime.Now,
                FirstName = _account.FirstName,
                Gender = _account.Gender,
                LastName = _account.LastName,
                PhoneNumber = _phoneNumberActions.PhoneNumber,
                Session = _zennoProfile.SessionName
            };
            return accountDbModel;
        }
    }
}
