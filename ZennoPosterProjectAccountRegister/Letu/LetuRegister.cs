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
using ZennoPosterProjectAccountRegister.Proxy;

namespace ZennoPosterProjectAccountRegister.Letu
{
    internal class LetuRegister : RegisterController
    {
        public LetuRegister(Instance instance, IZennoPosterProjectModel project) : base(instance, project)
        {
            LetuGenderOptions genderOptions = new LetuGenderOptions();
            Account = new AccountBuilder(genderOptions);
        }

        public override Account Account { get; }

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

        private void BeginRegister()
        {
            BrowserTab.UpdateToNextPage("https://www.letu.ru/", "https://www.google.com/");
            ActionsExecutor.Click()
        }
    }
}
