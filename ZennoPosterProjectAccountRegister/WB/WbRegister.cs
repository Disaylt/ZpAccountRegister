using NLog;
using SmartProxyV2_ZennoLabVersion.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ZennoLab.CommandCenter;
using ZennoLab.InterfacesLibrary.ProjectModel;
using ZennoPosterProjectAccountRegister.AccountStore;
using ZennoPosterProjectAccountRegister.AccountStore.WB;
using ZennoPosterProjectAccountRegister.BrowserTab;
using ZennoPosterProjectAccountRegister.Http;
using ZennoPosterProjectAccountRegister.Http.WB;
using ZennoPosterProjectAccountRegister.Logger;
using ZennoPosterProjectAccountRegister.Models.Bson;
using ZennoPosterProjectAccountRegister.Models.Json.WB;
using ZennoPosterProjectAccountRegister.MongoDB.WB;
using ZennoPosterProjectAccountRegister.OnlineSim;
using ZennoPosterProjectAccountRegister.OnlineSim.WB;
using ZennoPosterProjectAccountRegister.Proxy;
using ZennoPosterProjectAccountRegister.ZennoPoster;

namespace ZennoPosterProjectAccountRegister.WB
{
    internal class WbRegister : RegisterController
    {
        public override Account Account { get; }
        public IPhoneNumberActions PhoneNumberActions { get; }
        private ProjectLogger _logger { get; }

        internal WbRegister()
        {
            WbGenderOptions genderOptions = new WbGenderOptions();
            Account = new AccountBuilder(genderOptions);
            PhoneNumberActions = new WbPhoneNumber();
            _logger = new ProjectLogger();
        }
        public override void StartRegistration()
        {
            bool isWriteAccount = false;
            using (var acountProxy = new RussianAcountProxy())
            {
                try
                {
                    BrowserProxy.SetProxy(acountProxy.Proxy);
                    BeginBrowserRegister();
                    InputCode();
                    isWriteAccount = true;
                    WarmUpCookies();
                    SendPersonalInfo(acountProxy.Proxy);
                }
                catch (Exception ex)
                {
                    if (isWriteAccount)
                    {
                        isWriteAccount = false;
                        BadSave();
                    }
                    _logger.Error(ex);
                }
                finally
                {

                    if (isWriteAccount)
                    {
                        GoodSave();
                    }
                    PhoneNumberActions.CloseNumberAsync().Wait();
                }
            }
        }

        private void WarmUpCookies()
        {
            Thread.Sleep(2 * 1000);
            ActionsExecutor.Click(WbTabClickDataBuilder.ClickProfile);
            Thread.Sleep(2 * 1000);
            BrowserTab.UpdateToNextPage("https://www.wildberries.ru/lk/details");
            Thread.Sleep(2 * 1000);
        }

        private void SendPersonalInfo(ProxyModel proxy)
        {
            IPersonalInfoWriter personalInfoWriter = new WbPersonalInfoWriter(Account, proxy, ZennoPosterProject);
            personalInfoWriter.SetGender();
            personalInfoWriter.SetBirthDate();
            personalInfoWriter.SetPersonalInfo();
        }

        private void BeginBrowserRegister()
        {
            BrowserTab.UpdateToNextPage("https://www.wildberries.ru/", "https://www.google.com/");
            ActionsExecutor.Click(WbTabClickDataBuilder.ClickSignIn);
            string phoneNumber = GetPhoneNumberWithoutCountryCode();
            ActionsExecutor.Input(WbTabInputDataBuilder.InputPhoneCode, phoneNumber);
            ActionsExecutor.Click(WbTabClickDataBuilder.ClickGetCode);
        }

        private string GetPhoneNumberWithoutCountryCode()
        {
            string phoneNumberWithCode = PhoneNumberActions.PhoneNumber;
            PhoneCountryCodeConverter phoneCountryCodeConverter = new PhoneCountryCodeConverter(phoneNumberWithCode);
            string phoneNumberWithoutCode = phoneCountryCodeConverter.GetPhoneNumberWithoutCountryCode(Country.Russian);
            return phoneNumberWithoutCode;
        }

        private void InputCode()
        {
            OnlineSimMessageChecker messageChecker = new OnlineSimMessageChecker(90);
            string message = messageChecker.GetMessageAsync(PhoneNumberActions).Result;
            CodeScaner codeScaner = new CodeScaner(message);
            string code = codeScaner.GetCode();
            ActionsExecutor.Input(WbTabInputDataBuilder.InputPhoneCode, code);
        }
        private void BadSave()
        {
            ZennoProfile.SaveProfile(Project.Settings.PathForSaveBadAccount);
            AccountDbModel accountDb = CreateAccountDbData(false, false);
            WbBuyoutsShopMongoAccounts<AccountDbModel> wbBuyoutsShopMongo = new WbBuyoutsShopMongoAccounts<AccountDbModel>("badAccounts");
            wbBuyoutsShopMongo.Insert(accountDb);
        }

        private void GoodSave()
        {
            ZennoProfile.SaveProfile(Project.Settings.PathForSaveGoodAccount);
            AccountDbModel accountDb = CreateAccountDbData(true, false);
            WbBuyoutsShopMongoAccounts<AccountDbModel> wbBuyoutsShopMongo = new WbBuyoutsShopMongoAccounts<AccountDbModel>("accounts");
            wbBuyoutsShopMongo.Insert(accountDb);
        }

        private AccountDbModel CreateAccountDbData(bool isActive, bool inWork)
        {
            ZennoCookieContainer zennoCookieContainer = new ZennoCookieContainer(ZennoPosterProject.Profile.CookieContainer);
            string jsonCookies = zennoCookieContainer.ConvertToJsonString();
            AccountDbModel accountDbModel = new AccountDbModel
            {
                Cookies = jsonCookies,
                IsActive = isActive,
                InWork = inWork,
                CreateDate = DateTime.Now,
                FirstName = Account.FirstName,
                Gender = Account.Gender,
                LastName = Account.LastName,
                PhoneNumber = PhoneNumberActions.PhoneNumber,
                Session = ZennoProfile.SessionName
            };
            return accountDbModel;
        }
    }
}
