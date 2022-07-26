using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZennoLab.CommandCenter;
using ZennoLab.InterfacesLibrary.ProjectModel;
using ZennoPosterProjectAccountRegister.AccountStore;
using ZennoPosterProjectAccountRegister.AccountStore.Letu;
using ZennoPosterProjectAccountRegister.AccountStore.WB;
using ZennoPosterProjectAccountRegister.OnlineSim;
using ZennoPosterProjectAccountRegister.OnlineSim.Letu;
using ZennoPosterProjectAccountRegister.Proxy;

namespace ZennoPosterProjectAccountRegister.Letu
{
    internal class LetuRegister : RegisterController
    {
        public LetuRegister(Instance instance, IZennoPosterProjectModel project) : base(instance, project)
        {
            LetuGenderOptions genderOptions = new LetuGenderOptions();
            Account = new AccountBuilder(genderOptions);
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
                }
                catch (Exception ex)
                {

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
    }
}
