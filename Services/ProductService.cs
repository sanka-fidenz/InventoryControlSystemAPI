using InventoryControlSystemAPI.DTOs;
using InventoryControlSystemAPI.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace InventoryControlSystemAPI.Services
{
    public class ProductService : IProductService
    {
        private readonly AppDbContext _context;

        public ProductService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Product>> GetProducts()
        {
            return await _context.Products.ToListAsync();
        }

        public async Task<Product?> GetProduct(string id)
        {
            return await _context.Products.FindAsync(id);
        }

        public async Task<Product> CreateProduct(ProductCreateDto product)
        {
            var newProduct = new Product
            {
                Id = Guid.NewGuid().ToString(),
                Name = product.Name,
                Price = product.Price,
                CategoryId = product.CategoryId,
            };

            _context.Products.Add(newProduct);
            await _context.SaveChangesAsync();
            return newProduct;
        }

        public async Task<Product?> UpdateProduct(string id, ProductUpdateDto updatedProduct)
        {
            var existingProduct = await GetProduct(id);
            if (existingProduct == null)
            {
                return null;
            }

            if (updatedProduct.Name != null) existingProduct.Name = updatedProduct.Name;
            if (updatedProduct.Price != null) existingProduct.Price = updatedProduct.Price.Value;
            if (updatedProduct.CategoryId != null) existingProduct.CategoryId = updatedProduct.CategoryId;

            await _context.SaveChangesAsync();

            return existingProduct;
        }

        public async Task<bool> DeleteProduct(string id)
        {
            var product = await GetProduct(id);
            if (product == null)
            {
                return false;
            }

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}