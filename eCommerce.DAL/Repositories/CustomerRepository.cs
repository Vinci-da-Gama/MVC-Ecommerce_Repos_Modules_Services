using eCommerce.DAL.DataSet;
using eCommerce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.DAL.Repositories
{
    public class CustomerRepository : RepositoryBase<Customer>
    {
        public CustomerRepository(EcommerceDataset context) : base(context) {
            if (context == null)
                throw new ArgumentNullException();
        }
    }
}
