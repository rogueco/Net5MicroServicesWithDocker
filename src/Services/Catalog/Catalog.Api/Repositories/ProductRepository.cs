using System.Collections.Generic;
using System.Threading.Tasks;
using Catalog.Api.Data;
using Catalog.Api.Entities;
using MongoDB.Driver;

namespace Catalog.Api.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ICatalogContext _catalogContext;

        public ProductRepository(ICatalogContext catalogContext)
        {
            _catalogContext = catalogContext;
        }

        public async Task<IEnumerable<Product>> GetProducts() =>
            await _catalogContext.Products.Find(x => true).ToListAsync();

        public async Task<Product> GetProduct(string id) =>
            await _catalogContext.Products.Find(x => x.Id == id).FirstOrDefaultAsync();

        public async Task<IEnumerable<Product>> GetProductByName(string name)
        {
            FilterDefinition<Product> filter = Builders<Product>.Filter.Eq(x => x.Name, name);
            return await _catalogContext.Products.Find(filter).ToListAsync();
        }

        public async Task<IEnumerable<Product>> GetProductByCategory(string categoryName)
        {
            FilterDefinition<Product> filter = Builders<Product>.Filter.Eq(x => x.Category, categoryName);
            return await _catalogContext.Products.Find(filter).ToListAsync();
        }

        public async Task CreateProduct(Product product) =>
            await _catalogContext.Products.InsertOneAsync(product);

        public async Task<bool> UpdateProduct(Product product)
        {
            ReplaceOneResult updateResult = await _catalogContext.Products.ReplaceOneAsync(x => x.Id == product.Id, product);
            return updateResult.IsAcknowledged && updateResult.ModifiedCount > 0;
        }

        public async Task<bool> DeleteProduct(string id)
        {
            FilterDefinition<Product> filterDefinition = Builders<Product>.Filter.Eq(x => x.Id, id);
            DeleteResult deleteResult = await _catalogContext.Products.DeleteOneAsync(filterDefinition);

            return deleteResult.IsAcknowledged && deleteResult.DeletedCount > 0;
        }
    }
}