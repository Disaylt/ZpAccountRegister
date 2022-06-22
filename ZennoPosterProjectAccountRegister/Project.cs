using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZennoLab.CommandCenter;
using ZennoPosterProjectAccountRegister.Models.Objects;

namespace ZennoPosterProjectAccountRegister
{
    internal static class Project
    {
        private const string _settingsFileName = "projectSettings.json";
        internal static ProjectSettingsModel Settings { get; }

        static Project()
        {
            Settings = JsonFileLoader.LoadJson<ProjectSettingsModel>(_settingsFileName);
        }
    }
}
