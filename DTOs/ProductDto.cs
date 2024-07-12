namespace InventoryControlSystemAPI.DTOs
{
    public class ProductCreateDto
    {
        public string Name { get; set; }
        public int Price { get; set; }
        public string CategoryId { get; set; }
    }

    public class ProductUpdateDto
    {
        public string? Name { get; set; }
        public int? Price { get; set; }
        public string? CategoryId { get; set; }
    }
}