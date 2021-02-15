﻿namespace OnlineShop.ViewModels
{
    public record UserOrderViewModel
    {
        public int Id { get; init; }
        public string Name { get; init; }
        public string Phone { get; init; }
        public string Address { get; init; }
        public decimal TotalPrice { get; init; }
    }
}