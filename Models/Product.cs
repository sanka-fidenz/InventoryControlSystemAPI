public class Product
{
    public string Id { get; set; }
    public string Name { get; set; }
    public int Price { get; set; }
    public string CategoryId { get; set; }
    public Category Category { get; set; } = null!;
    public ICollection<Inventory> Inventories { get; } = new List<Inventory>();
}