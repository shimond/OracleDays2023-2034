namespace BasketApi.Model
{
    public record BasketItem(int productId, string productName, int amount, decimal pricePerUnit);
}
