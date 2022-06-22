using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZennoLab.CommandCenter;
using ZennoPosterProjectAccountRegister.Models.Objects;

namespace ZennoPosterProjectAccountRegister.BrowserTab
{
    internal class TabInputAction : ITabAction
    {
        public InputTabElementsModel InputTabElements {get;}
        private readonly Instance _instance;
        internal TabInputAction(InputTabElementsModel inputTabElements, Instance instance)
        {
            InputTabElements = inputTabElements;
            _instance = instance;
        }

        public void Begin()
        {
            _instance.WaitFieldEmulationDelay();
            var htmlElement = _instance.ActiveTab.GetDocumentByAddress("0").FindElementByXPath(InputTabElements.CurrentXPathElement, 0);
            htmlElement.SetValue(InputTabElements.InputText, _instance.EmulationLevel, true);
        }
    }
}
