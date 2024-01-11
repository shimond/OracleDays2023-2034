namespace MyCatalog.Contracts;
public interface IProductsRepository
{
    Task<Product> AddProductAsync(Product product);
    Task DeleteProductAsync(int id);
    Task<Product?> GetProductAsync(int id);
    Task<IEnumerable<Product>> GetProductsAsync();
    Task<Product> UpdateProductAsync(Product product);
}
