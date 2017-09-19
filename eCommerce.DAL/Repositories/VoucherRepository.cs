using eCommerce.DAL.DataSet;
using eCommerce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.DAL.Repositories
{
    public class VoucherRepository: RepositoryBase<Voucher>
    {
        public VoucherRepository(EcommerceDataset context)
            : base(context)
        {
            if (context == null)
                throw new ArgumentNullException();
        }
    }
}
