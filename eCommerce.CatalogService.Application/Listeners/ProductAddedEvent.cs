namespace eCommerce.CatalogService.Application.Listeners
{
    public record ProductAddedEvent(string messageId, string productId, string name, string description);
}
