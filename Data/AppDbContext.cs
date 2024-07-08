using Microsoft.EntityFrameworkCore;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Category> Categories { get; set; }
    public DbSet<Inventory> Inventories { get; set; }
    public DbSet<Location> Locations { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<Store> Stores { get; set; }
    public DbSet<StoreUser> StoreUsers { get; set; }
    public DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>()
            .HasMany(c => c.Products)
            .WithOne(p => p.Category)
            .HasForeignKey(p => p.CategoryId);

        modelBuilder.Entity<Product>()
            .HasMany(p => p.Inventories)
            .WithOne(i => i.Product)
            .HasForeignKey(i => i.ProductId);

        modelBuilder.Entity<Store>()
            .HasMany(s => s.Inventories)
            .WithOne(i => i.Store)
            .HasForeignKey(i => i.StoreId);

        modelBuilder.Entity<Store>()
            .HasOne(s => s.Location)
            .WithOne(l => l.Store)
            .HasForeignKey<Store>(s => s.LocationId);

        modelBuilder.Entity<StoreUser>()
            .HasKey(su => new { su.StoreId, su.UserId });

        modelBuilder.Entity<StoreUser>()
            .HasOne(su => su.Store)
            .WithMany(s => s.StoreUsers)
            .HasForeignKey(su => su.StoreId);

        modelBuilder.Entity<StoreUser>()
            .HasOne(su => su.User)
            .WithMany(u => u.StoreUsers)
            .HasForeignKey(su => su.UserId);

        modelBuilder.Entity<Role>()
            .HasMany(r => r.Users)
            .WithOne(u => u.Role)
            .HasForeignKey(u => u.RoleId);
    }
}