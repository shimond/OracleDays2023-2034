using Microsoft.Extensions.Caching.Distributed;
using System.Text.Json;

public interface ICacheService
{
    T Get<T>(string key);
    void Set<T>(string key, T value);
}

public class CacheService : ICacheService
{
    private readonly IDistributedCache _cache;

    public CacheService(IDistributedCache cache)
    {
        _cache = cache;
    }

    public T Get<T>(string key)
    {
        var value = _cache.GetString(key);
        return value != null ? JsonSerializer.Deserialize<T>(value) : default;
    }

    public void Set<T>(string key, T value)
    {
        var options = new DistributedCacheEntryOptions();
        var serializedValue = JsonSerializer.Serialize(value);
        _cache.SetString(key, serializedValue, options);
    }
}
