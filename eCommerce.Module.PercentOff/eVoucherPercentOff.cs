using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eCommerce.Contracts.iModels;
using eCommerce.Contracts.Repos;
using eCommerce.Contracts.ModuleInterfaces;

namespace eCommerce.Module.PercentOff
{
    public class eVoucherPercentOff : IeVoucher
    {
        public void ProcessVoucher(IVoucher vc, IBasket bkt, IBasketVoucher bv)
        {
            decimal basketTotal = bkt.BasketTotal();
            if (vc.MinSpend < basketTotal)
            {
                bv.Value = -vc.Value * (basketTotal / 100);
                bv.VoucherCode = vc.VoucherCode;
                bv.VoucherDescription = vc.VoucherDescription;
                bv.VoucherId = vc.VoucherId;
                bkt.AddBasketVoucher(bv);
            }
        }
    }
}
