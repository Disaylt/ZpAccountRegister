﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZennoLab.InterfacesLibrary.ProjectModel.Collections;

namespace ZennoPosterProjectAccountRegister.ZennoPoster
{
    internal class ZennoProfile
    {
        public string SessionName { get; }
        private readonly IProfile _profile;
        public ZennoProfile(string profileName)
        {
            SessionName = profileName;
            _profile = Program.ZennoPosterProject.Profile;
        }

        public void SaveProfile(string pathFolder)
        {
            string path = $@"{pathFolder}\{SessionName}.zpprofile";
            _profile.Save(path,
                false,
                true,
                true,
                true,
                true,
                true,
                true,
                true,
                true);
        }
    }
}
