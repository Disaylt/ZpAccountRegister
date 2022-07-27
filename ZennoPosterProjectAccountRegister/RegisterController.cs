using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZennoLab.CommandCenter;
using ZennoLab.InterfacesLibrary.ProjectModel;
using ZennoLab.InterfacesLibrary.ProjectModel.Collections;
using ZennoPosterProjectAccountRegister.AccountStore;
using ZennoPosterProjectAccountRegister.BrowserTab;
using ZennoPosterProjectAccountRegister.Logger;
using ZennoPosterProjectAccountRegister.OnlineSim;
using ZennoPosterProjectAccountRegister.Proxy;
using ZennoPosterProjectAccountRegister.RegisterService;
using ZennoPosterProjectAccountRegister.ZennoPoster;

namespace ZennoPosterProjectAccountRegister
{
    internal abstract class RegisterController
    {
        protected Account Account { get; }
        protected Instance Instance { get; }
        protected IZennoPosterProjectModel ZennoPosterProject { get; }
        protected BrowserTabHandler BrowserTab { get; }
        protected TabActionsExecutor ActionsExecutor { get; }
        protected InstanceProxy BrowserProxy { get; }
        protected ZennoProfile ZennoProfile { get; }
        protected ProjectLogger Logger { get; }

        internal RegisterController(Instance instance, IZennoPosterProjectModel project, RegisterOptions registerOptions)
        {
            Instance = instance;
            ZennoPosterProject = project;
            BrowserTab = new BrowserTabHandler(Instance);
            ActionsExecutor = new TabActionsExecutor(Instance);
            BrowserProxy = new InstanceProxy(Instance);
            ZennoProfile = CreateZennoProfile(registerOptions.SessionNameBuilder , project.Profile);
            Logger = new ProjectLogger();
            Account = registerOptions.Account;

        }
        public abstract void StartRegistration();
        protected virtual ZennoProfile CreateZennoProfile(SessionNameBuilder sessionBuilder, IProfile profile)
        {
            string profileName = sessionBuilder.CreateSessionName(32);
            var zennoProfile = new ZennoProfile(profileName, profile);
            return zennoProfile;
        }
    }
}
