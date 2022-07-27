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
using ZennoPosterProjectAccountRegister.RegisterService;
using ZennoPosterProjectAccountRegister.RegisterService.OptionBuilders;
using ZennoPosterProjectAccountRegister.TaskCompletion;
using ZennoPosterProjectAccountRegister.ZennoPoster;

namespace ZennoPosterProjectAccountRegister.WB
{
    internal class WbRegister : RegisterController
    {
        private readonly ITaskComplete _taskComplete;

        public IPhoneNumberActions PhoneNumberActions { get; }

        internal WbRegister(Instance instance, IZennoPosterProjectModel project, RegisterOptions registerOptions) : base(instance, project, registerOptions)
        {
            var wbOptions = registerOptions as WbRegisterOptions;
            PhoneNumberActions = wbOptions.PhoneNumberActions;
            _taskComplete = new WbTaskComplete(ZennoProfile, Account, project.Profile, wbOptions.PhoneNumberActions);
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
                    CheckAuthorization(acountProxy.Proxy);
                    CloseActiveSessions(acountProxy.Proxy);
                }
                catch (Exception ex)
                {
                    if (isWriteAccount)
                    {
                        isWriteAccount = false;
                        _taskComplete.BadEnd();
                    }
                    Logger.Error(ex);
                }
                finally
                {

                    if (isWriteAccount)
                    {
                        _taskComplete.GoodEnd();
                        Logger.Info($"Registration completed");
                    }
                    PhoneNumberActions.CloseNumberAsync().Wait();
                }
            }
        }

        private void CheckAuthorization(ProxyModel proxy)
        {
            Thread.Sleep(5 * 1000);
            WebWbAccount wbAccount = new WebWbAccount(proxy, ZennoPosterProject);
            if(!wbAccount.CompareAccountData(Account))
            {
                throw new Exception("Different account data");
            }
        }

        private void CloseActiveSessions(ProxyModel proxy)
        {
            BrowserTab.UpdateToNextPage("https://www.wildberries.ru/lk/details");
            WebWbAccount wbAccount = new WebWbAccount(proxy, ZennoPosterProject);
            WbAccountSettingsDataModel wbAccountSettingsData = wbAccount.GetAccountSettings();
            int numSessions = wbAccountSettingsData.MySafety.Sessions.Count;
            if (numSessions > 1)
            {
                ActionsExecutor.Click(WbTabClickDataBuilder.ClickCloseActiveSessions);
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
            ActionsExecutor.Input(WbTabInputDataBuilder.InputPhoneNumberToLogIn, phoneNumber);
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
    }
}
