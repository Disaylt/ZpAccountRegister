using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZennoPosterProjectAccountRegister.Models.Json.WB
{
    internal class WbAccountSettingsModel
    {
        [JsonProperty("value")]
        public WbAccountSettingsValue Value { get; set; }

    }

    internal class WbAccountSettingsValue
    {
        [JsonProperty("data")]
        public WbAccountSettingsData Data { get; set; }
    }

    internal class WbAccountSettingsData
    {
        [JsonProperty("mySafety")]
        WbAccountSettingsMySafety MySafety { get; set; }
    }

    internal class WbAccountSettingsMySafety
    {
        [JsonProperty("sessions")]
        List<WbAccountSettingsSession> Sessions { get; set; }
    }

    internal class WbAccountSettingsSession
    {
        [JsonProperty("sessionId")]
        public string SessionId { get; set; }
    }
}
