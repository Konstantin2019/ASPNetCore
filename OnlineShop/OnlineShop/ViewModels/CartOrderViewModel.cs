namespace OnlineShop.ViewModels
{
    public record CartOrderViewModel
    {
        public CartViewModel Cart { get; init; }
        public OrderViewModel Order { get; set; } = new();
    }
}
