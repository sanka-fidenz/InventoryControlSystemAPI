using InventoryControlSystemAPI.DTOs;

namespace InventoryControlSystemAPI.Services.Interfaces
{
    public interface ICategoryService
    {
        Task<IEnumerable<Category>> GetCategories();
        Task<Category?> GetCategory(string id);
        Task<Category> CreateCategory(CategoryDto newCategory);
        Task<Category?> UpdateCategory(string id, CategoryDto updatedCategory);
        Task<bool> DeleteCategory(string id);
    }
}