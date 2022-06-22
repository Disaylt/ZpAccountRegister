using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZennoLab.CommandCenter;

namespace ZennoPosterProjectAccountRegister.Models.Objects
{
    public class InputTabElementsModel : StandardTabElementsModel
    {
        public string InputText { get; }

        public InputTabElementsModel(string inputText, string currentXPathElement) : base(currentXPathElement)
        {
            InputText = inputText;
        }

        public InputTabElementsModel(string inputText, string currentXPathElement, string nextPageXpathElement) : base(currentXPathElement, nextPageXpathElement)
        {
            InputText = inputText;
        }
    }
}
