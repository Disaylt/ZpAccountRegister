using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ZennoPosterProjectAccountRegister.Models.Json.OnlineSim
{
    class MessageStateModel
    {
        [JsonProperty("message_to_code")]
        public int IsOnlyCode { get; set; }

        [JsonProperty("tzid")]
        public int TzId { get; set; }

        public MessageStateModel(int isOnlyCode, int tzId)
        {
            IsOnlyCode = isOnlyCode;
            TzId = tzId;
        }
    }
}
