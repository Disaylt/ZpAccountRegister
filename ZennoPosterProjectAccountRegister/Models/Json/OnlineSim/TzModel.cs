using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ZennoPosterProjectAccountRegister.Models.Json.OnlineSim
{
    class TzModel
    {
        [JsonProperty("response")]
        public int ResponseCode { get; set; }
        
        [JsonProperty("tzid")]
        public int Id { get; set; }
    }
}
