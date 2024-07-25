using InventoryControlSystemAPI.DTOs;

namespace InventoryControlSystemAPI.Services.Interfaces
{
    public interface ISalesService
    {
        Task<IEnumerable<Sales>> GetSales();
        Task<Sales?> GetSale(string id);
        Task<Sales> CreateSale(PurchaseCreateDto newSale);
        Task<Sales?> UpdateSale(string id, PurchaseUpdateDto updatedSale);
        Task<bool> DeleteSale(string id);
    }
}