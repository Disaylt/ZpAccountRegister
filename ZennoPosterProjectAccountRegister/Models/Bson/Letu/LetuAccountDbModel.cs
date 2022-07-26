using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZennoPosterProjectAccountRegister.Models.Bson.Letu
{
    internal class LetuAccountDbModel : AccountDbModel
    {
        [BsonElement("email")]
        public string Email { get; set; }
    }
}
