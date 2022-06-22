using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZennoPosterProjectAccountRegister.MongoDB.WB
{
    internal class WbMongoAccounts<T> : MongoConnector where T : IMongoCollectionModel
    {
        private const string _dbName = "buyouts_shop";
        protected IMongoCollection<T> Collection { get; }

        public WbMongoAccounts(string collectionName)
        {
            Collection = GetCollection<T>(collectionName, _dbName);
        }

        public void Insert(T model)
        {
            Collection.InsertOneAsync(model).Wait();
        }
    }
}
