using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZennoPosterProjectAccountRegister.RegisterService
{
    delegate RegisterOptions CreateRegisterControllerOptions();
    internal class OptionsCollector
    {
        private static OptionsCollector _instance;

        private OptionsCollector()
        {
            Options = new Dictionary<string, CreateRegisterControllerOptions>();
        }

        public static OptionsCollector Instance
        {
            get
            {
                if(_instance == null)
                {
                    _instance = new OptionsCollector();
                }
                return _instance;
            }
        }

        public Dictionary<string, CreateRegisterControllerOptions> Options { get; }

        private void AddCustomOptions()
        {
            
        }
    }
}
