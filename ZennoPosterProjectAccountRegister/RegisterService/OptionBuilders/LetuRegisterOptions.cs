using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZennoPosterProjectAccountRegister.AccountStore;
using ZennoPosterProjectAccountRegister.AccountStore.General;
using ZennoPosterProjectAccountRegister.OnlineSim;
using ZennoPosterProjectAccountRegister.OnlineSim.Letu;

namespace ZennoPosterProjectAccountRegister.RegisterService.OptionBuilders
{
    internal class LetuRegisterOptions : GeneralRegisterOptions
    {
        public IPhoneNumberActions PhoneNumberActions { get; }

        public LetuRegisterOptions()
        {
            PhoneNumberActions = new LetuPhoneNumber();
        }

        protected override Account CreateAccount()
        {
            GenderOptions genderOptions = new GeneralGenderOptions();
            Account account = new AccountBuilder(genderOptions);
            return account;
        }
    }
}
