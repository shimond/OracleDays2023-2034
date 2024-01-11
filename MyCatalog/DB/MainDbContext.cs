namespace MyCatalog.DB;

public class MainDbContext : DbContext
{
    public MainDbContext(DbContextOptions<MainDbContext> options) : base(options)
    {
    }

    public DbSet<Product> Products { get; set; } = default!;
}
