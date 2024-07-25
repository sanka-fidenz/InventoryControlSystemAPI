public class Product
{
    public string Id { get; set; }
    public string Name { get; set; }
    public int Price { get; set; }
    public string CategoryId { get; set; }
    public Category Category { get; set; } = null!;
    public List<InventoryProduct> InventoryProducts { get; } = [];
    public List<Purchase> Purchases { get; } = [];
    public List<Sales> Sales { get; } = [];
}
