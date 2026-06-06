namespace eCommerce.CatalogService.Domain.Models
{
    public class Product
    {
        public required string Id { get; set; }
        public required string Name { get; set; }
        public required string Description { get; set; }
    }
}
