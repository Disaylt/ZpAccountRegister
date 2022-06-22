﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;

namespace ZennoPosterProjectAccountRegister.MongoDB
{
    internal class MongoConnector
    {
        private static IMongoClient _client;

        internal MongoConnector()
        {
            if (_client == null )
            {
                _client = new MongoClient(Project.Settings.MongoConnectionString);
            }
        }

        internal IMongoCollection<T> GetCollection<T>(string collectionName, string databaseName) where T : IMongoCollectionModel
        {
            IMongoDatabase database = _client.GetDatabase(databaseName);
            IMongoCollection<T> collection = database.GetCollection<T>(collectionName);
            return collection;
        }
    }
}