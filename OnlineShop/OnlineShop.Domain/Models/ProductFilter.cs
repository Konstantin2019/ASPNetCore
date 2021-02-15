namespace OnlineShop.Domain.Models
{
    public record ProductFilter
    {
        public int? CategoryId { get; init; }
        public int? BrandId { get; init; }
        public int[] Ids { get; init; }
    }
}
