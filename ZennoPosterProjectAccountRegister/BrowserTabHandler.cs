using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZennoLab.CommandCenter;
using ZennoPosterProjectAccountRegister.Logger;

namespace ZennoPosterProjectAccountRegister
{
    public class BrowserTabHandler
    {
        protected readonly Tab Tab;
        private readonly ProjectLogger _logger;
        public BrowserTabHandler(Instance instance)
        {
            Tab = instance.ActiveTab;
            _logger = new ProjectLogger();
        }

        public void UpdateToNextPage(string url)
        {
            try
            {
                if (Tab.IsBusy) Tab.WaitDownloading();
                Tab.Navigate(url);
                if (Tab.IsBusy) Tab.WaitDownloading();
                _logger.Info($"{nameof(UpdateToNextPage)} - URL: {url}");

            }
            catch (Exception ex)
            {
                _logger.Error(ex, $"{nameof(UpdateToNextPage)} - URL: {url}");
            }
        }

        public void UpdateToNextPage(string url, string refer)
        {
            try
            {
                if (Tab.IsBusy) Tab.WaitDownloading();
                Tab.Navigate(url, refer);
                if (Tab.IsBusy) Tab.WaitDownloading();
                _logger.Info($"{nameof(UpdateToNextPage)} - URL: {url}, Refer: {refer}");
            }
            catch (Exception ex)
            {
                _logger.Error(ex, $"{nameof(UpdateToNextPage)} - URL: {url}, Refer: {refer}");
            }
        }
    }
}
