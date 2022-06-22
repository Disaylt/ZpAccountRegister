using System;
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

        protected IMongoCollection<T> GetCollection<T>(string collectionName, string databaseName)
        {
            IMongoDatabase database = _client.GetDatabase(databaseName);
            IMongoCollection<T> collection = database.GetCollection<T>(collectionName);
            return collection;
        }
    }
}
