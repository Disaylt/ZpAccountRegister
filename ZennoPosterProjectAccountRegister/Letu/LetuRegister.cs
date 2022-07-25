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
            throw new NotImplementedException();
        }
    }
}
