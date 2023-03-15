using GraphQL.Core.Entities;
using GraphQL.Core.Repositories;

namespace GraphQL.API.Queries {

    public class Query {
        public Task<IEnumerable<Product>> GetProductsAsync([Service] IProductRepository productRepository) =>
            productRepository.GetAllAsync();

        public Task<Product> GetProductById(string id, [Service] IProductRepository productRepository) =>
            productRepository.GetByIdAsync(id);
  
    }
}
