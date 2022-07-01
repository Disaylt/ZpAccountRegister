using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;
using ZennoPosterProjectAccountRegister.Logger;

namespace ZennoPosterProjectAccountRegister.MongoDB
{
    internal class MongoConnector
    {
        private static IMongoClient _client;
        protected ProjectLogger Logger { get; }

        internal MongoConnector()
        {
            if (_client == null )
            {
                _client = new MongoClient(Configuration.Settings.MongoConnectionString);
            }
            Logger =new ProjectLogger();
        }

        internal IMongoCollection<T> GetCollection<T>(string collectionName, string databaseName) where T : IMongoCollectionModel
        {
            IMongoDatabase database = _client.GetDatabase(databaseName);
            IMongoCollection<T> collection = database.GetCollection<T>(collectionName);
            Logger.Info($"{nameof(GetCollection)} - Collection: {collectionName}, database:{databaseName}");
            return collection;
        }
    }
}
