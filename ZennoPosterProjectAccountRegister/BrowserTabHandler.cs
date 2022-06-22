using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZennoLab.CommandCenter;

namespace ZennoPosterProjectAccountRegister
{
    public class BrowserTabHandler
    {
        protected readonly Tab Tab;
        public BrowserTabHandler(Instance instance)
        {
            Tab = instance.ActiveTab;
        }

        public void UpdateToNextPage(string url)
        {
            if (Tab.IsBusy) Tab.WaitDownloading();
            Tab.Navigate(url);
            if (Tab.IsBusy) Tab.WaitDownloading();
        }

        public void UpdateToNextPage(string url, string refer)
        {
            if (Tab.IsBusy) Tab.WaitDownloading();
            Tab.Navigate(url, refer);
            if (Tab.IsBusy) Tab.WaitDownloading();
        }
    }
}
