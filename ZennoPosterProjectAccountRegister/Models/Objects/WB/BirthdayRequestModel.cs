using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using ZennoPosterProjectAccountRegister.Http;

namespace ZennoPosterProjectAccountRegister.Models.Objects.WB
{
    internal class BirthdayRequestModel : IBodyStringConverter
    {
        public DateTime BirthdayDate { get; }

        public BirthdayRequestModel(DateTime date)
        {
            BirthdayDate = date;
        }

        public StringContent ConvertToStringContent()
        {
            string content = $"{nameof(BirthdayDate)}={BirthdayDate.ToShortDateString()}";
            StringContent stringContent = new StringContent(content);
            return stringContent;
        }
    }
}
