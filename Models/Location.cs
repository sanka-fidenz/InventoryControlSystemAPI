public class Location
{
    public string Id { get; set; }
    public string AddressLine1 { get; set; }
    public string AddressLine2 { get; set; }
    public string AddressLine3 { get; set; }
    public Store Store { get; set; } = null!;
}
