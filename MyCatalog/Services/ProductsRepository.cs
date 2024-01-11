namespace MyCatalog.Services;

public class ProductsRepository(MainDbContext dbContext) : IProductsRepository
{
    public async Task<Product> AddProductAsync(Product product)
    {
        await dbContext.Products.AddAsync(product);
        await dbContext.SaveChangesAsync();
        return product;
    }

    public async Task<Product?> GetProductAsync(int id)
    {
        return await dbContext.Products.FindAsync(id);
    }

    public async Task<Product> UpdateProductAsync(Product product)
    {
        dbContext.Products.Update(product);
        await dbContext.SaveChangesAsync();
        return product;
    }

    public async Task DeleteProductAsync(int id)
    {
        var product = await dbContext.Products.FindAsync(id);
        if (product is not null)
        {
            dbContext.Products.Remove(product);
            await dbContext.SaveChangesAsync();
        }
    }

    public async Task<IEnumerable<Product>> GetProductsAsync()
    {
        return await dbContext.Products.ToListAsync();
    }
}
