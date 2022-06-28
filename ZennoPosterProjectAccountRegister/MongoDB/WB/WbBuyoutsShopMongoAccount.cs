using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZennoPosterProjectAccountRegister.MongoDB.WB
{
    internal class WbBuyoutsShopMongoAccounts<T> : MongoConnector where T : IMongoCollectionModel
    {
        private const string _dbName = "buyouts_shop";
        protected IMongoCollection<T> Collection { get; }

        public WbBuyoutsShopMongoAccounts(string collectionName)
        {
            Collection = GetCollection<T>(collectionName, _dbName);
        }

        public void Insert(T model)
        {
            try
            {
                Collection.InsertOneAsync(model).Wait();
                Logger.Info($"Insert BSON document - Type: {typeof(T)}");
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
            }
        }
    }
}
