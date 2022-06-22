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
    internal static class WbTabInputDataBuilder
    {
        public static InputTabElementsModel InputPhoneNumberToLogIn(string phoneNumber)
        {
            string xPathInputElement = "//div[@class='login__phone form-block form-block--phone-dropdown']//div[@class='form-block__input']/input";
            InputTabElementsModel inputTabElements = new InputTabElementsModel(phoneNumber, xPathInputElement);
            return inputTabElements;
        }

        public static InputTabElementsModel InputPhoneCode(string phoneCode)
        {
            string xPathInputElement = "//input[@class='j-input-confirm-code val-msg']";
            InputTabElementsModel inputTabElements = new InputTabElementsModel(phoneCode, xPathInputElement);
            return inputTabElements;
        }
    }
}
