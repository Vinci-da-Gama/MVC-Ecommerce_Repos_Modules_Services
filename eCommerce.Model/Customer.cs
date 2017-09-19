using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eCommerce.Contracts.iModels;

namespace eCommerce.Models
{
    public class Customer : ICustomer
    {
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }

        public string Address1 { get; set; }
        public string Town { get; set; }
        public string PostCode { get; set; }
    }
}
