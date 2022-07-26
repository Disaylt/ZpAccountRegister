﻿using System;
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

        internal RegisterController(Instance instance, IZennoPosterProjectModel project)
        {
            Instance = instance;
            ZennoPosterProject = project;
            BrowserTab = new BrowserTabHandler(Instance);
            ActionsExecutor = new TabActionsExecutor(Instance);
            BrowserProxy = new InstanceProxy(Instance);
            ZennoProfile = CreateZennoProfile();
            Logger = new ProjectLogger();

        }
        public abstract void StartRegistration();
        private ZennoProfile CreateZennoProfile()
        {
            SessionNameBuilder sessionBuilder = new SessionNameBuilder(true, true);
            string profileName = sessionBuilder.CreateSessionName(32);
            var zennoProfile = new ZennoProfile(profileName, ZennoPosterProject.Profile);
            return zennoProfile;
        }
    }
}
