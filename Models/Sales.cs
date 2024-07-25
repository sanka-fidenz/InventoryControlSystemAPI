public class Sales
{
    public string Id { get; set; }
    public int Count { get; set; }
    public int Price { get; set; }
    public string StoreId { get; set; }
    public Store Store { get; set; } = null!;
    public string ProductId { get; set; }
    public Product Product { get; set; } = null!;
    public DateTime CreatedDate { get; set; }
    public DateTime UpdatedDate { get; set; }
}
