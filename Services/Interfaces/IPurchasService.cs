using InventoryControlSystemAPI.DTOs;

namespace InventoryControlSystemAPI.Services.Interfaces
{
    public interface IPurchaseService
    {
        Task<IEnumerable<Purchase>> GetPurchases();
        Task<Purchase?> GetPurchase(string id);
        Task<Purchase> CreatePurchase(PurchaseCreateDto newPurchase);
        Task<Purchase?> UpdatePurchase(string id, PurchaseUpdateDto updatedPurchase);
        Task<bool> DeletePurchase(string id);
    }
}