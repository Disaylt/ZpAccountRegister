using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZennoPosterProjectAccountRegister.WB;

namespace ZennoPosterProjectAccountRegister.RegisterService
{
    internal class RussianMarketplaceServices : RegistrationServices
    {
        public override Dictionary<string, RegisterController> Services { get; }

        public RussianMarketplaceServices()
        {
            Services = new Dictionary<string, RegisterController>();
            AddServices();
        }

        private void AddServices()
        {
            Services.Add("wb", new WbRegister());
        }
    }
}
