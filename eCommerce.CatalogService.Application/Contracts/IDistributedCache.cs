namespace eCommerce.CatalogService.Application.Contracts
{
    /// <summary>
    /// Mocked distributed Cache
    /// </summary>
    public interface IDistributedCache
    {
        public Task<string> GetStringAsync(string cacheKey);

        public Task SetStringAsync(string cacheKey, string value, TimeSpan timeSpan);
    }
}
