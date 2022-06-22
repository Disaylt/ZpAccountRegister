using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using ZennoPosterProjectAccountRegister.Http;

namespace ZennoPosterProjectAccountRegister.Models.Objects.WB
{
    internal class GenderRequestModel : IBodyStringConverter
    {
        public string Gender { get; }

        public GenderRequestModel(string gender)
        {
            Gender = gender;
        }

        public StringContent ConvertToStringContent()
        {
            string content = $"sex={Gender}";
            StringContent stringContent = new StringContent(content);
            return stringContent;
        }
    }
}
