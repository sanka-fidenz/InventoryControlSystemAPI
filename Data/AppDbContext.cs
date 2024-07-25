using Microsoft.EntityFrameworkCore;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Category> Categories { get; set; }
    public DbSet<Inventory> Inventories { get; set; }
    public DbSet<InventoryProduct> InventoryProducts { get; set; }
    public DbSet<Location> Locations { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Purchase> Purchases { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<Sales> Saless { get; set; }
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
            .HasMany(p => p.InventoryProducts)
            .WithOne(i => i.Product)
            .HasForeignKey(i => i.ProductId);

        modelBuilder.Entity<Inventory>()
            .HasMany(p => p.InventoryProducts)
            .WithOne(i => i.Inventory)
            .HasForeignKey(i => i.InventoryId);

        modelBuilder.Entity<Inventory>()
            .HasOne(i => i.Store)
            .WithOne(s => s.Inventory)
            .HasForeignKey<Inventory>(i => i.StoreId);

        modelBuilder.Entity<Store>()
            .HasOne(s => s.Location)
            .WithOne(l => l.Store)
            .HasForeignKey<Store>(s => s.LocationId);

        modelBuilder.Entity<InventoryProduct>()
            .HasKey(ip => new { ip.ProductId, ip.InventoryId });

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

        modelBuilder.Entity<Sales>()
            .HasOne(s => s.Product)
            .WithMany(i => i.Sales)
            .HasForeignKey(s => s.ProductId);

        modelBuilder.Entity<Sales>()
            .HasOne(s => s.Store)
            .WithMany(s => s.Sales)
            .HasForeignKey(s => s.StoreId);

        modelBuilder.Entity<Purchase>()
            .HasOne(s => s.Product)
            .WithMany(i => i.Purchases)
            .HasForeignKey(s => s.ProductId);

        modelBuilder.Entity<Purchase>()
            .HasOne(s => s.Store)
            .WithMany(s => s.Purchases)
            .HasForeignKey(s => s.StoreId);

        modelBuilder.Entity<Role>().HasData(
            new Role { Id = "1", Name = "Operator" },
            new Role { Id = "2", Name = "Manager" }
        );

        modelBuilder.Entity<User>().HasData(
            new User { Id = Guid.NewGuid().ToString(), RoleId = "1", Name = "Operator" },
            new User { Id = Guid.NewGuid().ToString(), RoleId = "2", Name = "Manager" }
        );
    }
}