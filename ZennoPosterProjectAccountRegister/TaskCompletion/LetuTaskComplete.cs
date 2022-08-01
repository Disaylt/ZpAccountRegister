using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZennoLab.InterfacesLibrary.ProjectModel.Collections;
using ZennoPosterProjectAccountRegister.AccountStore;
using ZennoPosterProjectAccountRegister.Models.Bson.Letu;
using ZennoPosterProjectAccountRegister.MongoDB.Letu;
using ZennoPosterProjectAccountRegister.OnlineSim;
using ZennoPosterProjectAccountRegister.ZennoPoster;

namespace ZennoPosterProjectAccountRegister.TaskCompletion
{
    internal class LetuTaskComplete : ITaskComplete
    {
        private readonly ZennoProfile _zennoProfile;
        private readonly Account _account;
        private readonly IPhoneNumberActions _phoneNumberActions;
        private readonly Configuration _configuration;
        public LetuTaskComplete(ZennoProfile zennoProfile, Account account, IPhoneNumberActions phoneNumber)
        {
            _zennoProfile = zennoProfile;
            _account = account;
            _phoneNumberActions = phoneNumber;
            _configuration = Configuration.Instance;
        }

        public void BadEnd()
        {
            string pathBadAccounts = _configuration.GetAccountsRouteForCurrentSeller().PathForSaveBadAccount;
            _zennoProfile.SaveProfile(pathBadAccounts);
            LetuAccountDbModel accountDb = CreateAccountDbData(false, false);
            LetuBuyoutsShopMongoAccounts<LetuAccountDbModel> wbBuyoutsShopMongo = new LetuBuyoutsShopMongoAccounts<LetuAccountDbModel>("badAccounts");
            wbBuyoutsShopMongo.Insert(accountDb);
        }

        public void GoodEnd()
        {
            string pathGoodAccounts = _configuration.GetAccountsRouteForCurrentSeller().Marketplace;
            _zennoProfile.SaveProfile(pathGoodAccounts);
            LetuAccountDbModel accountDb = CreateAccountDbData(true, false);
            LetuBuyoutsShopMongoAccounts<LetuAccountDbModel> wbBuyoutsShopMongo = new LetuBuyoutsShopMongoAccounts<LetuAccountDbModel>("accounts");
            wbBuyoutsShopMongo.Insert(accountDb);
        }

        private LetuAccountDbModel CreateAccountDbData(bool isActive, bool inWork)
        {
            LetuAccountDbModel accountDbModel = new LetuAccountDbModel
            {
                Cookies = string.Empty,
                IsActive = isActive,
                InWork = inWork,
                CreateDate = DateTime.Now,
                FirstName = _account.FirstName,
                Gender = _account.Gender,
                LastName = _account.LastName,
                PhoneNumber = _phoneNumberActions.PhoneNumber,
                Session = _zennoProfile.SessionName,
                Email = _account.Email
            };
            return accountDbModel;
        }
    }
}
