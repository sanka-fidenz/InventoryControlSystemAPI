using InventoryControlSystemAPI.DTOs;
using InventoryControlSystemAPI.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace InventoryControlSystemAPI.Services
{
    public class PurchaseService : IPurchaseService
    {
        private readonly AppDbContext _context;

        public PurchaseService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Purchase>> GetPurchases()
        {
            return await _context.Purchases.ToListAsync();
        }

        public async Task<Purchase?> GetPurchase(string id)
        {
            return await _context.Purchases.FindAsync(id);
        }

        public async Task<Purchase> CreatePurchase(PurchaseCreateDto purchase)
        {
            var newPurchase = new Purchase
            {
                Id = Guid.NewGuid().ToString(),
                Count = purchase.Count,
                Price = purchase.Price,
                StoreId = purchase.StoreId,
                ProductId = purchase.ProductId
            };

            _context.Purchases.Add(newPurchase);
            await _context.SaveChangesAsync();
            return newPurchase;
        }

        public async Task<Purchase?> UpdatePurchase(string id, PurchaseUpdateDto updatedPurchase)
        {
            var existingPurchase = await GetPurchase(id);
            if (existingPurchase == null)
            {
                return null;
            }

            if (updatedPurchase.Count != null) existingPurchase.Count = (int)updatedPurchase.Count;
            if (updatedPurchase.Price != null) existingPurchase.Price = updatedPurchase.Price.Value;
            if (updatedPurchase.StoreId != null) existingPurchase.StoreId = updatedPurchase.StoreId;
            if (updatedPurchase.ProductId != null) existingPurchase.ProductId = updatedPurchase.ProductId;

            await _context.SaveChangesAsync();

            return existingPurchase;
        }

        public async Task<bool> DeletePurchase(string id)
        {
            var purchase = await GetPurchase(id);
            if (purchase == null)
            {
                return false;
            }

            _context.Purchases.Remove(purchase);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}