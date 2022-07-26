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
    }
}
