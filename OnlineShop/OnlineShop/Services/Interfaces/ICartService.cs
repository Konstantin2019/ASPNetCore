using OnlineShop.ViewModels;

namespace OnlineShop.Services.Interfaces
{
    public interface ICartService
    {
        void Increment(int id);
        void Decrement(int id);
        void Remove(int id);
        void Clear();
        CartViewModel GetViewModel();
    }
}
