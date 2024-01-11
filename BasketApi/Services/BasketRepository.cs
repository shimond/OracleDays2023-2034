using BasketApi.Model;
using Microsoft.Extensions.Caching.Distributed;

namespace BasketApi.Services
{
    public class BasketRepository(ICacheService cache)
    {

        public Task SetItem(string userId, BasketItem item)
        {
            cache.Set(userId, item);
            return Task.CompletedTask;
        }

        public Task<BasketItem?> GetItem(string userId)
        {
            return Task.FromResult(cache.Get<BasketItem>(userId));
        }

    }
}
