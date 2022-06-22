using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ZennoLab.CommandCenter;
using ZennoPosterProjectAccountRegister.Models.Objects;

namespace ZennoPosterProjectAccountRegister.BrowserTab
{
    public delegate T ClickElement<out T>() where T : StandardTabElementsModel;
    public delegate T InputElement<out T>(string inputText) where T : InputTabElementsModel;
    internal class TabActionsExecutor
    {
        private const int _maxWhileCheck = 60;
        private readonly Instance _instance;
        internal TabActionsExecutor(Instance instance) 
        {
            _instance = instance;
        }

        public virtual void Click(ClickElement<StandardTabElementsModel> clickElement)
        {
            StandardTabElementsModel standardTabElements = clickElement.Invoke();
            ITabAction tabAction = new TabClickAction(standardTabElements, _instance);
            WaitAction(tabAction, standardTabElements);
        }

        public virtual void Input(InputElement<InputTabElementsModel> inputElement, string inputText)
        {
            InputTabElementsModel inputTabElements = inputElement.Invoke(inputText);
            ITabAction tabAction = new TabInputAction(inputTabElements, _instance);
            WaitAction(tabAction, inputTabElements);
        }

        protected virtual void WaitAction(ITabAction tabAction, StandardTabElementsModel standardTabElements)
        {
            if (ElementExists(standardTabElements.CurrentXPathElement))
            {
                tabAction.Begin();
                if (!ElementExists(standardTabElements.NextPageXpathElement))
                {
                    throw new Exception("Html element not found");
                }
            }
            else
            {
                throw new Exception("Html element not found");
            }
        }

        private bool ElementExists(string xPath)
        {
            if(xPath != null)
            {
                for(int i = 0; i < _maxWhileCheck; i++)
                {
                    var htmlElement = _instance.ActiveTab.GetDocumentByAddress("0").FindElementByXPath(xPath, 0);
                    if(!htmlElement.IsNull && !htmlElement.IsVoid)
                    {
                        return true;
                    }
                    Thread.Sleep(1000);
                }
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
