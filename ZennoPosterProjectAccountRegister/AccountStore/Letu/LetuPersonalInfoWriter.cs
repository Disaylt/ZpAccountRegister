using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ZennoPosterProjectAccountRegister.BrowserTab;
using ZennoPosterProjectAccountRegister.Letu;

namespace ZennoPosterProjectAccountRegister.AccountStore.Letu
{
    internal class LetuPersonalInfoWriter : IPersonalInfoWriter
    {
        private Account _account;
        private TabActionsExecutor _actionsExecutor;

        public LetuPersonalInfoWriter(Account account, TabActionsExecutor tabActionsExecutor)
        {
            _account = account;
            _actionsExecutor = tabActionsExecutor;
        }

        public void UpdatePersonalInfo()
        {
            _actionsExecutor.Input(LetuTabInputDataBuilder.InputEmail, _account.Email);
            _actionsExecutor.Input(LetuTabInputDataBuilder.InputFirstName, _account.FirstName);
            _actionsExecutor.Input(LetuTabInputDataBuilder.InputLastName, _account.LastName);
            _actionsExecutor.Click(LetuTabClickDataBuilder.ClickSavePersonalInfo);
        }
    }
}
