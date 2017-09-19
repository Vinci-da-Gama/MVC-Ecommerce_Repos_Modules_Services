using System;

namespace eCommerce.Contracts.iModels
{
    public interface IBasketItem
    {
        Guid BasketId { get; set; }
        int BasketItemId { get; set; }
        IProduct IProduct { get; set; }
        int ProductId { get; set; }
        int Quantity { get; set; }
    }
}