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
    internal static class Configuration
    {
        public static string ProjectFolder { get; } = @"C:\Users\user\Desktop\git\Buyouts-shop account register\ZennoPosterSolutionAccountRegister\ZennoPosterProjectAccountRegister\bin\Debug\files"; //zennoposter is stupid, and not see project folder path. Because need to specify where the files will be stored
        private const string _settingsFileName = "projectSettings.json";
        internal static ProjectSettingsModel Settings { get; private set; }

        static Configuration()
        {
            Load();
        }

        public static void Load()
        {
            Settings = JsonFileLoader.LoadJson<ProjectSettingsModel>($@"{ProjectFolder}\{_settingsFileName}");
        }
    }
}
