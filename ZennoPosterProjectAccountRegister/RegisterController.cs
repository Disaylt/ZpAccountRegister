using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZennoLab.CommandCenter;
using ZennoLab.InterfacesLibrary.ProjectModel;
using ZennoPosterProjectAccountRegister.AccountStore;
using ZennoPosterProjectAccountRegister.BrowserTab;
using ZennoPosterProjectAccountRegister.Logger;
using ZennoPosterProjectAccountRegister.OnlineSim;
using ZennoPosterProjectAccountRegister.Proxy;
using ZennoPosterProjectAccountRegister.ZennoPoster;

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
        protected ZennoProfile ZennoProfile { get; }
        protected ProjectLogger Logger { get; }

        internal RegisterController()
        {
            Instance = Program.Instance;
            ZennoPosterProject = Program.ZennoPosterProject;
            BrowserTab = new BrowserTabHandler(Instance);
            ActionsExecutor = new TabActionsExecutor(Instance);
            BrowserProxy = new InstanceProxy(Instance);
            ZennoProfile = CreateZennoProfile();
            Logger = new ProjectLogger();

        }
        public abstract void StartRegistration();

        private ZennoProfile CreateZennoProfile()
        {
            string profileName;
            if(string.IsNullOrEmpty(Configuration.Settings.SessionName))
            {
                SessionBuilder sessionBuilder = new SessionBuilder(true, true);
                profileName = sessionBuilder.CreateSessionName(32);
                Configuration.Settings.SessionName = profileName;
            }
            else
            {
                profileName = Configuration.Settings.SessionName;
            }
            var zennoProfile = new ZennoProfile(profileName);
            return zennoProfile;
        }
    }
}
