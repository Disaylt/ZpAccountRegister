using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZennoLab.CommandCenter;
using ZennoPosterProjectAccountRegister.BrowserTab;
using ZennoPosterProjectAccountRegister.Models.Objects;

namespace ZennoPosterProjectAccountRegister.WB
{

    internal static class WbTabClickDataBuilder
    {
        public static StandardTabElementsModel ClickSignIn()
        {
            string xPathSignIn = "//a[@data-wba-header-name='Login']";
            string xPathNextElement = "//div[@class='sign-in-page']";
            StandardTabElementsModel standardTabElementsModel = new StandardTabElementsModel(xPathSignIn, xPathNextElement);
            return standardTabElementsModel;
        }

        public static StandardTabElementsModel ClickGetCode()
        {
            string xPathGetCode = "//button[@class='login__btn btn-main-lg']";
            string xPathNextElement = "//form[@id='spaAuthForm']";
            StandardTabElementsModel standardTabElementsModel = new StandardTabElementsModel(xPathGetCode, xPathNextElement);
            return standardTabElementsModel;
        }

        public static StandardTabElementsModel ClickProfile()
        {
            string xPathProfileButton = "//a[@data-wba-header-name='LK']";
            string xPathNextElement = "//div[@class='lk-item lk-item--user']";
            StandardTabElementsModel standardTabElementsModel = new StandardTabElementsModel(xPathProfileButton, xPathNextElement);
            return standardTabElementsModel;
        }
    }
}
