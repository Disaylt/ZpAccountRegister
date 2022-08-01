using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZennoPosterProjectAccountRegister.Models.Objects
{
    public class ProjectSettingsModel
    {
        public string GenderRegister { get; set; }
        public DateTime MinRegisterBirthDate { get; set; }
        public DateTime MaxRegisterBirthDate { get; set; }
        public string Marketplace { get; set; }
        public string MongoConnectionString { get; set; }
    }
}
