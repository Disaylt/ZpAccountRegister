using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ZennoPosterProjectAccountRegister.Models.Json.OnlineSim
{
    class PhoneModel
    {
        [JsonProperty("country")]
        public int Country { get; set; }

        [JsonProperty("sum")]
        public int Sum { get; set; }

        [JsonProperty("service")]
        public string Service { get; set; }

        [JsonProperty("number")]
        public string Number { get; set; }

        [JsonProperty("msg")]
        public string Message { get; set; }

        [JsonProperty("response")]
        public string ResponseStatus { get; set; }

        [JsonProperty("tzid")]
        public int TzId { get; set; }

        [JsonProperty("time")]
        public int Time { get; set; }
    }
}
