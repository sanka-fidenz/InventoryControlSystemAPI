using InventoryControlSystemAPI.DTOs;
using InventoryControlSystemAPI.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace InventoryControlSystemAPI.Services
{
    public class SalesService : ISalesService
    {
        private readonly AppDbContext _context;

        public SalesService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Sales>> GetSales()
        {
            return await _context.Saless.ToListAsync();
        }

        public async Task<Sales?> GetSale(string id)
        {
            return await _context.Saless.FindAsync(id);
        }

        public async Task<Sales> CreateSale(PurchaseCreateDto sale)
        {
            var newSale = new Sales
            {
                Id = Guid.NewGuid().ToString(),
                Count = sale.Count,
                Price = sale.Price,
                StoreId = sale.StoreId,
                ProductId = sale.ProductId
            };

            _context.Saless.Add(newSale);
            await _context.SaveChangesAsync();
            return newSale;
        }

        public async Task<Sales?> UpdateSale(string id, PurchaseUpdateDto updatedSales)
        {
            var existingSales = await GetSale(id);
            if (existingSales == null)
            {
                return null;
            }

            if (updatedSales.Count != null) existingSales.Count = (int)updatedSales.Count;
            if (updatedSales.Price != null) existingSales.Price = updatedSales.Price.Value;
            if (updatedSales.StoreId != null) existingSales.StoreId = updatedSales.StoreId;
            if (updatedSales.ProductId != null) existingSales.ProductId = updatedSales.ProductId;

            await _context.SaveChangesAsync();

            return existingSales;
        }

        public async Task<bool> DeleteSale(string id)
        {
            var Sales = await GetSale(id);
            if (Sales == null)
            {
                return false;
            }

            _context.Saless.Remove(Sales);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}