using eCommerce.CatalogService.Application.Contracts;

namespace eCommerce.CatalogService.Application.Implementations
{
    /// <summary>
    /// TODO: use concrete implementation
    /// </summary>
    public class DistributedCache : IDistributedCache
    {
        public async Task<string> GetStringAsync(string cacheKey)
        {
            return await Task.FromResult(string.Empty);
        }

        public async Task SetStringAsync(string cacheKey, string value, TimeSpan timeSpan)
        {
            await Task.CompletedTask;
        }
    }
}
