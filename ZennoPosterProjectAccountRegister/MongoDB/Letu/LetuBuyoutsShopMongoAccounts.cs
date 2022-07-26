using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZennoPosterProjectAccountRegister.MongoDB.Letu
{
    internal class LetuBuyoutsShopMongoAccounts<T> : MongoConnector where T : IMongoCollectionModel
    {
        private const string _dbName = "letual";
        protected IMongoCollection<T> Collection { get; }

        public LetuBuyoutsShopMongoAccounts(string collectionName)
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
