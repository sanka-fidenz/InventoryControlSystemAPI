using InventoryControlSystemAPI.DTOs;

namespace InventoryControlSystemAPI.Services.Interfaces
{
    public interface IInventoryService
    {
        Task<IEnumerable<Inventory>> GetInventories(string? storeId, string? productId);
        Task<Inventory?> GetInventory(string id);
        Task<Inventory> CreateInventory(InventoryCreateDto newInventory);
        Task<Inventory?> UpdateInventory(string id, InventoryUpdateDto updatedInventory);
        Task<bool> DeleteInventory(string id);
    }
}