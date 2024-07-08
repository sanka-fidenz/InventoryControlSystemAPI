public class Role
{
    public string Id { get; set; }
    public string Name { get; set; }
    public ICollection<User> Users { get; } = new List<User>();
}