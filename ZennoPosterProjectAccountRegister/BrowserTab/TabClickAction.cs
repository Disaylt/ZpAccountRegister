using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZennoLab.CommandCenter;
using ZennoPosterProjectAccountRegister.Models.Objects;

namespace ZennoPosterProjectAccountRegister.BrowserTab
{
    internal class TabClickAction : ITabAction
    {
        public StandardTabElementsModel StandardTabElements { get; }
        private readonly Instance _instance;
        internal TabClickAction(StandardTabElementsModel standardTabElements, Instance instance)
        {
            StandardTabElements = standardTabElements;
            _instance = instance;
        }

        public void Begin()
        {
            _instance.WaitFieldEmulationDelay();
            var htmlElement = _instance.ActiveTab.GetDocumentByAddress("0").FindElementByXPath(StandardTabElements.CurrentXPathElement, 0);
            htmlElement.RiseEvent("click", _instance.EmulationLevel);
        }
    }
}
