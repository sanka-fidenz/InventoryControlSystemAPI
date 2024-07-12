using InventoryControlSystemAPI.DTOs;
using InventoryControlSystemAPI.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace InventoryControlSystemAPI.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly AppDbContext _context;

        public CategoryService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Category>> GetCategories()
        {
            return await _context.Categories.ToListAsync();
        }

        public async Task<Category?> GetCategory(string id)
        {
            return await _context.Categories.FindAsync(id);
        }

        public async Task<Category> CreateCategory(CategoryDto Category)
        {
            var newCategory = new Category
            {
                Id = Guid.NewGuid().ToString(),
                Name = Category.Name
            };

            _context.Categories.Add(newCategory);
            await _context.SaveChangesAsync();
            return newCategory;
        }

        public async Task<Category?> UpdateCategory(string id, CategoryDto updatedCategory)
        {
            var existingCategory = await GetCategory(id);
            if (existingCategory == null)
            {
                return null;
            }

            existingCategory.Name = updatedCategory.Name;

            await _context.SaveChangesAsync();

            return existingCategory;
        }

        public async Task<bool> DeleteCategory(string id)
        {
            var Category = await GetCategory(id);
            if (Category == null)
            {
                return false;
            }

            _context.Categories.Remove(Category);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}