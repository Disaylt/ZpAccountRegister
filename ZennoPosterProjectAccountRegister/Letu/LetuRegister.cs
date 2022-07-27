using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ZennoLab.CommandCenter;
using ZennoLab.InterfacesLibrary.ProjectModel;
using ZennoPosterProjectAccountRegister.AccountStore;
using ZennoPosterProjectAccountRegister.AccountStore.Letu;
using ZennoPosterProjectAccountRegister.AccountStore.WB;
using ZennoPosterProjectAccountRegister.Http;
using ZennoPosterProjectAccountRegister.Models.Bson;
using ZennoPosterProjectAccountRegister.Models.Bson.Letu;
using ZennoPosterProjectAccountRegister.MongoDB.Letu;
using ZennoPosterProjectAccountRegister.MongoDB.WB;
using ZennoPosterProjectAccountRegister.OnlineSim;
using ZennoPosterProjectAccountRegister.OnlineSim.Letu;
using ZennoPosterProjectAccountRegister.Proxy;
using ZennoPosterProjectAccountRegister.RegisterService;

namespace ZennoPosterProjectAccountRegister.Letu
{
    internal class LetuRegister : RegisterController
    {
        public LetuRegister(Instance instance, IZennoPosterProjectModel project, RegisterOptions registerOptions) : base(instance, project, registerOptions)
        {
            LetuGenderOptions genderOptions = new LetuGenderOptions();
            IEmailCreator emailCreator = new YandexEmailCreator(project.Profile);
            Account = new AccountBuilder(genderOptions, emailCreator);
            PhoneNumberActions = new LetuPhoneNumber();
        }

        public override Account Account { get; }
        public IPhoneNumberActions PhoneNumberActions { get; }

        public override void StartRegistration()
        {
            bool isWriteAccount = false;
            using (var acountProxy = new RussianAcountProxy())
            {
                try
                {
                    BrowserProxy.SetProxy(acountProxy.Proxy);
                    FirstActionForRegistration();
                    InputCode();
                    isWriteAccount = true;
                    UpdatePersonalInfo();
                    WarpUpCookies();
                }
                catch (Exception ex)
                {
                    if (isWriteAccount)
                    {
                        isWriteAccount = false;
                        BadSave();
                    }
                    Logger.Error(ex);
                }
                finally
                {
                    if (isWriteAccount)
                    {
                        GoodSave();
                        Logger.Info($"Registration completed");
                    }
                    PhoneNumberActions.CloseNumberAsync().Wait();
                }
            }
        }

        private void FirstActionForRegistration()
        {
            BrowserTab.UpdateToNextPage("https://www.letu.ru/", "https://www.google.com/");
            ActionsExecutor.Click(LetuTabClickDataBuilder.ClickStartRegister);
            string phoneNumber = GetPhoneNumberWithoutCountryCode();
            ActionsExecutor.Input(LetuTabInputDataBuilder.InputPhoneNumberToLogIn, phoneNumber);
            ActionsExecutor.Click(LetuTabClickDataBuilder.ClickGetCode);
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
            ActionsExecutor.Input(LetuTabInputDataBuilder.InputCode, code);
            Thread.Sleep(5 * 1000);
        }

        private void UpdatePersonalInfo()
        {
            BrowserTab.UpdateToNextPage("https://www.letu.ru/account/profile");
            LetuPersonalInfoWriter letuPersonalInfoWriter = new LetuPersonalInfoWriter(Account, ActionsExecutor);
            letuPersonalInfoWriter.UpdatePersonalInfo();
            Thread.Sleep(5 * 1000);
        }

        private void WarpUpCookies()
        {
            Thread.Sleep(5 * 1000);
            BrowserTab.UpdateToNextPage("https://www.letu.ru/account/profile");
            Thread.Sleep(5 * 1000);
        }

        private void BadSave()
        {
            ZennoProfile.SaveProfile(Configuration.Settings.PathForSaveBadAccount);
            LetuAccountDbModel accountDb = CreateAccountDbData(false, false);
            LetuBuyoutsShopMongoAccounts<LetuAccountDbModel> wbBuyoutsShopMongo = new LetuBuyoutsShopMongoAccounts<LetuAccountDbModel>("badAccounts");
            wbBuyoutsShopMongo.Insert(accountDb);
        }

        private void GoodSave()
        {
            ZennoProfile.SaveProfile(Configuration.Settings.PathForSaveGoodAccount);
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
                FirstName = Account.FirstName,
                Gender = Account.Gender,
                LastName = Account.LastName,
                PhoneNumber = PhoneNumberActions.PhoneNumber,
                Session = ZennoProfile.SessionName,
                Email = Account.Email
            };
            return accountDbModel;
        }
    }
}
