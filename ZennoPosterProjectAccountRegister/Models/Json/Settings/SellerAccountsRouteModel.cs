using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZennoPosterProjectAccountRegister.Models.Json.Settings
{
    internal class SellerAccountsRouteModel
    {
        public string Marketplace { get; set; }
        public string PathForSaveGoodAccount { get; set; }
        public string PathForSaveBadAccount { get; set; }
    }
}
