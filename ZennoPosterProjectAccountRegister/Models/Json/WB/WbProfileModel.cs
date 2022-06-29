using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZennoPosterProjectAccountRegister.Models.Json.WB
{
    public class WbProfileModel
    {
        [JsonProperty("value")]
        public WbProfile ProfileData { get; set; }
    }

    public class WbProfile
    {
        [JsonProperty("firstName")]
        public string FirstName { get; set; }

        [JsonProperty("lastName")]
        public string LastName { get; set; }

        [JsonProperty("isAuthenticated")]
        public bool IsAuthenticated { get; set; }
    }
}
