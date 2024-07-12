public class Inventory
{
    public string Id { get; set; }
    public int Count { get; set; }
    public string ProductId { get; set; }
    public Product Product { get; set; } = null!;
    public string StoreId { get; set; }
    public Store Store { get; set; } = null!;
}
