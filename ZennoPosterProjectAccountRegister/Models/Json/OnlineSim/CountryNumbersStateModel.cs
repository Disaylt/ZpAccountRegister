using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZennoPosterProjectAccountRegister.Models.Json.OnlineSim
{
    internal class CountryNumbersStateModel
    {
        public string Name { get; set; }
        public int Position { get; set; }
        public int Code { get; set; }
        public bool Enabled { get; set; }
        public List<ServiceModel> Services { get; set; }
    }
}
