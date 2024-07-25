public class Role
{
    public string Id { get; set; }
    public string Name { get; set; }
    public List<User> Users { get; } = [];
}