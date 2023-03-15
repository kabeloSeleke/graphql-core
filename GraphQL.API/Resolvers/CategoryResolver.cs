using GraphQL.Core.Entities;
using GraphQL.Core.Repositories;

namespace GraphQL.API.Resolvers {
    [ExtendObjectType(Name = "Category")]
    public class CategoryResolver {
        public Task<Category> GetCategoryAsync(
          [Parent] Product product,
          [Service] ICategoryRepository categoryRepository) => categoryRepository.GetById(product.CategoryId);
    }
}