using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZennoLab.CommandCenter;
using ZennoLab.InterfacesLibrary.ProjectModel;
using ZennoPosterProjectAccountRegister.Letu;
using ZennoPosterProjectAccountRegister.WB;

namespace ZennoPosterProjectAccountRegister.RegisterService
{
    internal class RussianMarketplaceServices : RegistrationServices
    {
        public override Dictionary<string, RegisterController> Services { get; }
        private readonly Instance _instance;
        private readonly IZennoPosterProjectModel _project;

        public RussianMarketplaceServices(Instance instance, IZennoPosterProjectModel project)
        {
            Services = new Dictionary<string, RegisterController>();
            _instance = instance;
            _project = project;
            AddServices();
        }

        private void AddServices()
        {
            Services.Add("wb", new WbRegister(_instance, _project));
            Services.Add("letu", new LetuRegister(_instance, _project));
        }
    }
}
