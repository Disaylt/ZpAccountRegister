using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using ZennoPosterProjectAccountRegister.Http;

namespace ZennoPosterProjectAccountRegister.Models.Objects
{
    public class HttpRequestContentModel<ContentType> : HttpRequestModel
    {
        public SetBody<ContentType> SetBody { get; }
        public HttpRequestContentModel(string url, HttpMethod httpMethod, SetHeaders setterHeaders, SetBody<ContentType> setBody) : base(url, httpMethod, setterHeaders)
        {
            SetBody = setBody;
        }
    }
}
