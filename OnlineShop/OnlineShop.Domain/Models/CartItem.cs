namespace OnlineShop.Domain.Models
{
    public record CartItem
    {
        public int ProductId { get; init; }
        public int Quantity { get; set; } = 1;
    }
}
