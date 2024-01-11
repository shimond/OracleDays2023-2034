using Microsoft.AspNetCore.Http.HttpResults;

namespace MyCatalog.Apis
{
    public static class ProductsApi
    {
        public static void AddProductApis(this WebApplication app)
        {
            var productGroup = app.MapGroup("products");

            productGroup.MapGet("", GetProductAsync)
                .Produces<IEnumerable<Product>>();

            productGroup.MapPost("", AddProduct)
                .RequireAuthorization()
                .Produces<Product>();

            productGroup.MapGet("test", () => "WOW")
                .RequireAuthorization(x => x.RequireRole("admin"))
                .Produces<Product>();

        }

        public static async Task<Ok<List<Product>>> GetProductAsync(IProductsRepository repository)
        {
            var products = await repository.GetProductsAsync();
            return TypedResults.Ok(products.ToList());
        }

        public static async Task<Results<BadRequest<Product>, Created<Product>>> AddProduct(IProductsRepository repository, Product product)
        {
            if (product.Price < 10)
            {
                return TypedResults.BadRequest<Product>(product);
            }
            var newProduct = await repository.AddProductAsync(product);
            return TypedResults.Created($"/products/{newProduct.Id}", newProduct);
        }







    }
}









