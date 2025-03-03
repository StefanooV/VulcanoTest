using MongoDB.Driver;
using VulcanoTest.Models;

namespace VulcanoTest.Infraestructura.Data
{
    public class ProductRepository
    {
        private readonly DatabaseContext _context;

        public ProductRepository(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<List<Product>> GetAllAsync()
        {
            return await _context.Products.Find(_ => true).ToListAsync();
        }

        public async Task<Product?> GetByIdAsync(string id)
        {
            return await _context.Products.Find(p => p.Id == id).FirstOrDefaultAsync();
        }

        public async Task CreateAsync(Product product)
        {
            await _context.Products.InsertOneAsync(product);
        }

        public async Task UpdateAsync(string id, Product productIn)
        {
            await _context.Products.ReplaceOneAsync(p => p.Id == id, productIn);
        }

        public async Task DeleteAsync(string id)
        {
            await _context.Products.DeleteOneAsync(p => p.Id == id);
        }
    }
}