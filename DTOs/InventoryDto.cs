namespace InventoryControlSystemAPI.DTOs
{
    public class InventoryCreateDto
    {
        public int Count { get; set; }
        public string ProductId { get; set; }
        public string StoreId { get; set; }
    }

    public class InventoryUpdateDto
    {
        public int Count { get; set; }
    }
}