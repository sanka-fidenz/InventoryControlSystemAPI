public class Store
{
    public string Id { get; set; }
    public string LocationId { get; set; }
    public Location Location { get; set; } = null!;
    public ICollection<Inventory> Inventories { get; } = new List<Inventory>();
    public ICollection<StoreUser> StoreUsers { get; set; }
}