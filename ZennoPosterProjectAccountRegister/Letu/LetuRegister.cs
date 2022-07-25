using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZennoLab.CommandCenter;
using ZennoLab.InterfacesLibrary.ProjectModel;
using ZennoPosterProjectAccountRegister.AccountStore;

namespace ZennoPosterProjectAccountRegister.Letu
{
    internal class LetuRegister : RegisterController
    {
        public LetuRegister(Instance instance, IZennoPosterProjectModel project) : base(instance, project)
        {

        }

        public override Account Account => throw new NotImplementedException();

        public override void StartRegistration()
        {
            throw new NotImplementedException();
        }
    }
}
