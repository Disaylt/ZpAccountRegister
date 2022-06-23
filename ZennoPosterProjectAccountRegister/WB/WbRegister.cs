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
using ZennoPosterProjectAccountRegister.Models.Bson;
using ZennoPosterProjectAccountRegister.Models.Json.WB;
using ZennoPosterProjectAccountRegister.MongoDB.WB;
using ZennoPosterProjectAccountRegister.OnlineSim;
using ZennoPosterProjectAccountRegister.OnlineSim.WB;
using ZennoPosterProjectAccountRegister.Proxy;

namespace ZennoPosterProjectAccountRegister.WB
{
    internal class WbRegister : RegisterController
    {
        public override Account Account { get; }
        public IPhoneNumberActions PhoneNumberActions { get; }

        internal WbRegister()
        {
            Account = CreateWbAccount();
            PhoneNumberActions = new WbPhoneNumber();
        }
        public override void StartRegistration()
        {
            using (var acountProxy = new RussianAcountProxy())
            {
                BrowserProxy.SetProxy(acountProxy.Proxy);
                BeginBrowserRegister();
                InputCode();
                WarmUpCookies();
                SendPersonalInfo(acountProxy.Proxy);
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
            string phoneNumberWithCode = PhoneNumberActions
                .GetPhoneDataAsync()
                .Result
                .Number;
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

        private Account CreateWbAccount()
        {
            Dictionary<string, IPersonalInfo> genderPersonalInfo = new Dictionary<string, IPersonalInfo>
            {
                {"male", new WbMalePersonalInfo() },
                {"female", new WbFemalePersonalInfo() }
            };
            GenderOptions genderOptions = new GenderOptions(genderPersonalInfo);
            Account account = new AccountBuilder(genderOptions);
            return account;
        }



        private AccountDbModel CreateAccountDbData(bool isActive, bool inWork)
        {
            ZennoCookieContainer zennoCookieContainer = new ZennoCookieContainer(ZennoPosterProject.Profile.CookieContainer);
            SessionBuilder sessionBuilder = new SessionBuilder(true, true);
            AccountDbModel accountDbModel = new AccountDbModel
            {
                Cookies = zennoCookieContainer.ConvertToJsonString(),
                IsActive = isActive,
                InWork = inWork,
                CreateDate = DateTime.Now,
                FirstName = Account.FirstName,
                Gender = Account.Gender,
                LastName = Account.LastName,
                PhoneNumber = PhoneNumberActions.PhoneNumber,
                Session = sessionBuilder.CreateSessionName(16)
            };
            return accountDbModel;
        }
    }
}
