public class Category
{
    public string Id { get; set; }
    public string Name { get; set; }
    public ICollection<Product> Products { get; } = new List<Product>();
}

public class CategoryDto
{
    public string Name { get; set; }
}