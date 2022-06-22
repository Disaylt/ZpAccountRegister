using Global.ZennoLab.Json.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZennoPosterProjectAccountRegister.Models.Bson
{
    internal class AccountDbModel
    {
        [BsonId]
        public BsonObjectId Id { get; set; }
        
        [BsonElement("session")]
        public string Session { get; set; }

        [BsonElement("cookies")]
        public string Cookies { get; set; }

        [BsonElement("first_name")]
        public string FirstName { get; set; }

        [BsonElement("last_name")]
        public string LastName { get; set; }

        [BsonElement("phoneNumber")]
        public string PhoneNumber { get; set; }

        [BsonElement("date")]
        public DateTime CreateDate { get; set; }

        [BsonElement("is_active")]
        public bool IsActive { get; set; }

        [BsonElement("in_work")]
        public bool InWork { get; set; }

        [BsonElement("sex")]
        public string Gender { get; set; }

        [BsonElement("proxy")]
        public string Proxy { get; set; } = string.Empty;

        [BsonElement("user_some_id")]
        public string UserSomeId { get; set; } = string.Empty;
    }
}
