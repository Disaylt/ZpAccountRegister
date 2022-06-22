using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZennoLab.CommandCenter;
using ZennoLab.InterfacesLibrary.ProjectModel;
using ZennoPosterProjectAccountRegister.AccountStore;
using ZennoPosterProjectAccountRegister.BrowserTab;
using ZennoPosterProjectAccountRegister.OnlineSim;
using ZennoPosterProjectAccountRegister.Proxy;

namespace ZennoPosterProjectAccountRegister
{
    internal abstract class RegisterController
    {
        public abstract Account Account { get; }
        protected Instance Instance { get; }
        protected IZennoPosterProjectModel ZennoPosterProject { get; }
        protected BrowserTabHandler BrowserTab { get; }
        protected TabActionsExecutor ActionsExecutor { get; }
        protected InstanceProxy BrowserProxy { get; }
        internal RegisterController()
        {
            Instance = Program.Instance;
            ZennoPosterProject = Program.ZennoPosterProject;
            BrowserTab = new BrowserTabHandler(Instance);
            ActionsExecutor = new TabActionsExecutor(Instance);
            BrowserProxy = new InstanceProxy(Instance);
        }
        public abstract void StartRegistration();
    }
}
