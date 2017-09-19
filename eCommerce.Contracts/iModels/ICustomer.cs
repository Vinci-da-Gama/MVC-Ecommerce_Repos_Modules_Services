namespace eCommerce.Contracts.iModels
{
    public interface ICustomer
    {
        string Address1 { get; set; }
        int CustomerId { get; set; }
        string CustomerName { get; set; }
        string PostCode { get; set; }
        string Town { get; set; }
    }
}