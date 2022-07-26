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

        public static InputTabElementsModel InputFirstName(string firstName)
        {
            string xPathInputElement = "//input[@name='firstName']";
            InputTabElementsModel inputTabElements = new InputTabElementsModel(firstName, xPathInputElement);
            return inputTabElements;
        }

        public static InputTabElementsModel InputLastName(string lastName)
        {
            string xPathInputElement = "//input[@name='lastName']";
            InputTabElementsModel inputTabElements = new InputTabElementsModel(lastName, xPathInputElement);
            return inputTabElements;
        }

        public static InputTabElementsModel InputEmail(string email)
        {
            string xPathInputElement = "//input[@name='email']";
            InputTabElementsModel inputTabElements = new InputTabElementsModel(email, xPathInputElement);
            return inputTabElements;
        }
    }
}
