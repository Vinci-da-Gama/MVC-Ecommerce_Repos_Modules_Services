using System;
using System.Collections.Generic;

namespace eCommerce.Contracts.iModels
{
    public interface IOrder
    {
        int CustomerId { get; set; }
        DateTime OrderDate { get; set; }
        int OrderId { get; set; }
        ICollection<IOrderItem> OrderItems { get; set; }
    }
}