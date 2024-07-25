public class Store
{
    public string Id { get; set; }
    public string LocationId { get; set; }
    public Location Location { get; set; } = null!;
    public Inventory Inventory { get; } = null!;
    public List<StoreUser> StoreUsers { get; } = [];
    public List<Sales> Sales { get; } = [];
    public List<Purchase> Purchases { get; } = [];
}

public class StoreDto
{
    public string LocationId { get; set; }
}