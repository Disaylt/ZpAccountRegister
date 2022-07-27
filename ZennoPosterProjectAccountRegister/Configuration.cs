using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZennoLab.CommandCenter;
using ZennoLab.InterfacesLibrary.ProjectModel;
using ZennoPosterProjectAccountRegister.Models.Objects;

namespace ZennoPosterProjectAccountRegister
{
    internal static class Configuration
    {
        private const string _settingsFileName = "projectSettings.json";
        private static readonly object _settingsLock = new object();
        public static ProjectSettingsModel Settings { get; private set; }
        public static string ProjectFilesFolder { get; private set; }

        public static void Load(IZennoPosterProjectModel project)
        {
            lock(_settingsLock)
            {
                ProjectFilesFolder = $@"{project.Path}files\";
                Settings = JsonFileLoader.LoadJson<ProjectSettingsModel>($"{ProjectFilesFolder}{_settingsFileName}");
            }
        }
    }
}
