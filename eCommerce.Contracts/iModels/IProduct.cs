namespace eCommerce.Contracts.iModels
{
    public interface IProduct
    {
        decimal CostPrice { get; set; }
        string Description { get; set; }
        string ImageUrl { get; set; }
        decimal Price { get; set; }
        int ProductId { get; set; }
    }
}