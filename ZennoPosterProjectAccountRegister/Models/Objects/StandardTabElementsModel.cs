using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZennoLab.CommandCenter;

namespace ZennoPosterProjectAccountRegister.Models.Objects
{
    public class StandardTabElementsModel
    {
        public string CurrentXPathElement { get; }
        public string NextPageXpathElement { get; }

        public StandardTabElementsModel(string currentXPathElement)
        {
            CurrentXPathElement = currentXPathElement;
        }

        public StandardTabElementsModel(string currentXPathElement, string nextPageXpathElement)
        {
            CurrentXPathElement = currentXPathElement;
            NextPageXpathElement = nextPageXpathElement;
        }
    }
}
