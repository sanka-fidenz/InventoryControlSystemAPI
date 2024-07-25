using InventoryControlSystemAPI.DTOs;
using InventoryControlSystemAPI.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace InventoryControlSystemAPI.Services
{
    public class InventoryService : IInventoryService
    {
        private readonly AppDbContext _context;

        public InventoryService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Inventory>> GetInventories(string? storeId, string? productId)
        {
            var query = _context.Inventories.AsQueryable();

            if (!string.IsNullOrEmpty(storeId))
            {
                query = query.Where(inventory => inventory.StoreId == storeId);
            }

            return await query.ToListAsync();
        }

        public async Task<Inventory?> GetInventory(string id)
        {
            return await _context.Inventories.FindAsync(id);
        }

        public async Task<Inventory> CreateInventory(InventoryCreateDto inventory)
        {
            var newInventory = new Inventory
            {
                Id = Guid.NewGuid().ToString(),
                StoreId = inventory.StoreId
            };
            _context.Inventories.Add(newInventory);
            await _context.SaveChangesAsync();
            return newInventory;
        }

        public async Task<bool> DeleteInventory(string id)
        {
            var Inventory = await GetInventory(id);
            if (Inventory == null)
            {
                return false;
            }
            _context.Inventories.Remove(Inventory);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}