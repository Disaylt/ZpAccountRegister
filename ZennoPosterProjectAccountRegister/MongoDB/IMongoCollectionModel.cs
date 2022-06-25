﻿using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZennoPosterProjectAccountRegister.MongoDB
{
    internal interface IMongoCollectionModel
    {
        [BsonId]
        BsonObjectId Id { get; set; }
    }
}
