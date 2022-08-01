using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZennoLab.CommandCenter;
using ZennoLab.InterfacesLibrary.ProjectModel;
using ZennoPosterProjectAccountRegister.Models.Json.Settings;
using ZennoPosterProjectAccountRegister.Models.Objects;

namespace ZennoPosterProjectAccountRegister
{
    internal class Configuration
    {
        private List<SellerAccountsRouteModel> _sellersAccountsRoute;
        private const string _settingsFileName = "projectSettings.json";
        private const string _routeFileName = "sellersAccountsRoute.json";
        private readonly object _settingsLock;
        private static Configuration _instance;

        private Configuration()
        {
            _settingsLock = new object();
        }

        public static Configuration Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new Configuration();
                }
                return _instance;
            }
        }
        public ProjectSettingsModel Settings { get; private set; }
        public string ProjectFilesFolder { get; private set; }
        public void Load(IZennoPosterProjectModel project)
        {
            lock(_settingsLock)
            {
                ProjectFilesFolder = $@"{project.Path}files\";
                Settings = JsonFileLoader.LoadJson<ProjectSettingsModel>($"{ProjectFilesFolder}{_settingsFileName}");
                _sellersAccountsRoute = JsonFileLoader.LoadJson<List<SellerAccountsRouteModel>>($"{ProjectFilesFolder}{_routeFileName}") ?? new List<SellerAccountsRouteModel>();
            }
        }

        public SellerAccountsRouteModel GetAccountsRouteForCurrentSeller()
        {
            SellerAccountsRouteModel sellerAccountsRoute = GetAccountsRoute(Settings.Marketplace);
            return sellerAccountsRoute;
        }

        public SellerAccountsRouteModel GetAccountsRoute(string seller)
        {
            SellerAccountsRouteModel sellerAccountsRoute = _sellersAccountsRoute.FirstOrDefault(x=> x.Marketplace == seller);
            if (sellerAccountsRoute == null)
            {
                throw new Exception("Path settings for seller does not exist");
            }
            else
            {
                return sellerAccountsRoute;
            }
        }
    }
}
