using GraphQL.Core.Entities;
using GraphQL.Infrastructure.Configurations;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphQL.Infrastructure.Data {
    public class CatalogContext : ICatalogContext {
        private const string ProductCollectionName = "Products";
        private const string CategoryCollectionName = "Categories";
        public IMongoCollection<Category> Categories { get; }
        public IMongoCollection<Product> Products { get; }

        public CatalogContext(MongoDbConfiguration mongoDbConfiguration) {
            var client = new MongoClient(mongoDbConfiguration.ConnectionString);
            var database = client.GetDatabase(mongoDbConfiguration.Database);

            this.Categories = database.GetCollection<Category>(CategoryCollectionName);
            this.Products = database.GetCollection<Product>(ProductCollectionName);

            CatalogContextSeed.SeedData(this.Categories, this.Products);
        }

        
    }
}
