public class User
{
    public string Id { get; set; }
    public string Name { get; set; }
    public List<StoreUser> StoreUsers { get; } = [];
    public string RoleId { get; set; }
    public Role Role { get; set; } = null!;
}

public class UserDto
{
    public string Name { get; set; }
    public string RoleId { get; set; }
}