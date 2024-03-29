﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZennoPosterProjectAccountRegister.Models.Json.OnlineSim;

namespace ZennoPosterProjectAccountRegister.OnlineSim
{
    public class OnlineSimSettings
    {
        private const string settingsFileName = "OnlineSim.json";
        protected readonly OnlineSimSettingModel Settings;

        public OnlineSimSettings()
        {
            var config = Configuration.Instance;
            Settings = JsonFileLoader.LoadJson<OnlineSimSettingModel>($@"{config.ProjectFilesFolder}\{settingsFileName}");
        }
    }
}