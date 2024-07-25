namespace InventoryControlSystemAPI.DTOs
{
    public class PurchaseCreateDto
    {
        public int Count { get; set; }
        public int Price { get; set; }
        public string StoreId { get; set; }
        public string ProductId { get; set; }
    }

    public class PurchaseUpdateDto
    {
        public int? Count { get; set; }
        public int? Price { get; set; }
        public string? StoreId { get; set; }
        public string? ProductId { get; set; }
    }
}