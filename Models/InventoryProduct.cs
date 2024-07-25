public class InventoryProduct
{
    public string InventoryId { get; set; }
    public string ProductId { get; set; }
    public Inventory Inventory { get; set; } = null!;
    public Product Product { get; set; } = null!;
    public int Count { get; set; }
}
