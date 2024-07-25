public class Inventory
{
    public string Id { get; set; }
    public string StoreId { get; set; }
    public Store Store { get; set; } = null!;
    public List<InventoryProduct> InventoryProducts { get; } = [];
}
