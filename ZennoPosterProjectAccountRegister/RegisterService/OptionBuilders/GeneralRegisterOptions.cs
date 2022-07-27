using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZennoPosterProjectAccountRegister.AccountStore;
using ZennoPosterProjectAccountRegister.AccountStore.General;

namespace ZennoPosterProjectAccountRegister.RegisterService.OptionBuilders
{
    internal class GeneralRegisterOptions : RegisterOptions
    {
        public GeneralRegisterOptions()
        {
            SessionNameBuilder = new SessionNameBuilder(true, true);
            Account = CreateAccount();
        }

        public override SessionNameBuilder SessionNameBuilder { get; protected set; }
        public override Account Account { get; protected set; }

        protected virtual Account CreateAccount()
        {
            GeneralGenderOptions genderOptions = new GeneralGenderOptions();
            Account account = new AccountBuilder(genderOptions);
            return account;
        }
    }
}