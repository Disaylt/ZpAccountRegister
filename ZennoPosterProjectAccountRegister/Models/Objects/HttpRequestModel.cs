using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using ZennoPosterProjectAccountRegister.Http;

namespace ZennoPosterProjectAccountRegister.Models.Objects
{
    public class HttpRequestModel
    {
        public SetHeaders SetHeaders { get; }
        public HttpMethod HttpMethod { get; }
        public string Url { get; }

        public HttpRequestModel(string url, HttpMethod httpMethod, SetHeaders setterHeaders)
        {
            SetHeaders = setterHeaders;
            HttpMethod = httpMethod;
            Url = url;
        }
    }
}
