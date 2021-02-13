namespace OnlineShop.ViewModels
{
    public class CartOrderViewModel
    {
        public CartViewModel Cart { get; init; }
        public OrderViewModel Order { get; set; } = new();
    }
}
