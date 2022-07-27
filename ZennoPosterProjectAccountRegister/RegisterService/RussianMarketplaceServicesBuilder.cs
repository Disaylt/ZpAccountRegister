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
    internal class RussianMarketplaceServicesBuilder : RegistrationServices
    {
        public override Dictionary<string, CreateRegisterContoller> Services { get; }
        private readonly Instance _instance;
        private readonly IZennoPosterProjectModel _project;

        public RussianMarketplaceServicesBuilder(Instance instance, IZennoPosterProjectModel project)
        {
            Services = new Dictionary<string, CreateRegisterContoller>();
            _instance = instance;
            _project = project;
            AddCustomServices();
        }

        private void AddCustomServices()
        {
            Services.Add("wb", (options) => new WbRegister(_instance, _project));
            Services.Add("letu", (options) => new LetuRegister(_instance, _project));
        }
    }
}
