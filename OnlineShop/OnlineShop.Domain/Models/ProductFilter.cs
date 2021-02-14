namespace OnlineShop.Domain.Models
{
    public class ProductFilter
    {
        public int? CategoryId { get; init; }
        public int? BrandId { get; init; }
        public int[] Ids { get; set; }
    }
}
