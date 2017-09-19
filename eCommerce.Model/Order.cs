using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eCommerce.Contracts.iModels;

namespace eCommerce.Models
{
    public class Order : IOrder
    {
        public int OrderId { get; set; }

        public DateTime OrderDate { get; set; }

        public int CustomerId { get; set; }

        public ICollection<IOrderItem> OrderItems { get; set; }
    }
}
