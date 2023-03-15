using GraphQL.Core.Entities;
using GraphQL.Core.Repositories;
using GraphQL.Infrastructure.Data;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphQL.Infrastructure.Repositories {
    public class CategoryRepository : ICategoryRepository {
        private readonly ICatalogContext catalogContext;

        public CategoryRepository(ICatalogContext catalogContext) {
            this.catalogContext = catalogContext;
        }

        public async Task<Category> GetById(string id) {
            var filter = Builders<Category>.Filter.Eq(_ => _.Id, id);

            return await this.catalogContext.Categories.Find(filter).FirstOrDefaultAsync();
        }
    }
}
