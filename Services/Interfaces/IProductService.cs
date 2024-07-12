using InventoryControlSystemAPI.DTOs;

namespace InventoryControlSystemAPI.Services.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> GetProducts();
        Task<Product?> GetProduct(string id);
        Task<Product> CreateProduct(ProductCreateDto newProduct);
        Task<Product?> UpdateProduct(string id, ProductUpdateDto updatedProduct);
        Task<bool> DeleteProduct(string id);
    }
}