using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZennoPosterProjectAccountRegister.OnlineSim
{
    public enum Country
    {
        Russian,
        Belarus
    }

    public class PhoneCountryCodeConverter
    {
        protected string PhoneNumber { get; }

        public PhoneCountryCodeConverter(string phoneNumber)
        {
            PhoneNumber = phoneNumber;
        }

        public string GetPhoneNumberWithoutCountryCode(Country country)
        {
            switch (country)
            {
                case Country.Russian:
                    return PhoneNumber.Substring(2);
                case Country.Belarus:
                    return PhoneNumber.Substring(4);
                default:
                    return PhoneNumber;
            }
        }
    }
}
