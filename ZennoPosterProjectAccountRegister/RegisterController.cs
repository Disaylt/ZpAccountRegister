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

        internal RegisterController()
        {
            Instance = Program.Instance;
            ZennoPosterProject = Program.ZennoPosterProject;
            BrowserTab = new BrowserTabHandler(Instance);
            ActionsExecutor = new TabActionsExecutor(Instance);
            BrowserProxy = new InstanceProxy(Instance);
            ZennoProfile = CreateZennoProfile();

        }
        public abstract void StartRegistration();

        private ZennoProfile CreateZennoProfile()
        {
            string profileName;
            if(string.IsNullOrEmpty(Project.Settings.SessionName))
            {
                SessionBuilder sessionBuilder = new SessionBuilder(true, true);
                profileName = sessionBuilder.CreateSessionName(32);
                Project.Settings.SessionName = profileName;
            }
            else
            {
                profileName = Project.Settings.SessionName;
            }
            var zennoProfile = new ZennoProfile(profileName);
            return zennoProfile;
        }
    }
}
