namespace eCommerce.Contracts.iModels
{
    public interface IOrderItem
    {
        string Description { get; set; }
        string ImageUrl { get; set; }
        int OrderItemId { get; set; }
        decimal Price { get; set; }
        int ProductId { get; set; }
        int Quantity { get; set; }
    }
}