using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZennoPosterProjectAccountRegister.Models.Objects;

namespace ZennoPosterProjectAccountRegister.Letu
{
    internal class LetuTabInputDataBuilder
    {
        public static InputTabElementsModel InputPhoneNumberToLogIn(string phoneNumber)
        {
            string xPathInputElement = "//input[@data-at-phone-input]";
            InputTabElementsModel inputTabElements = new InputTabElementsModel(phoneNumber, xPathInputElement);
            return inputTabElements;
        }

        public static InputTabElementsModel InputCode(string code)
        {
            string xPathInputElement = "//input[@data-at-code-input='inputCode-0']";
            InputTabElementsModel inputTabElements = new InputTabElementsModel(code, xPathInputElement);
            return inputTabElements;
        }
    }
}
