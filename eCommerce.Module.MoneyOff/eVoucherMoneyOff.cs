using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eCommerce.Contracts.iModels;
using eCommerce.Contracts.Repos;
using eCommerce.Contracts.ModuleInterfaces;

namespace eCommerce.Module.MoneyOff
{
    public class eVoucherMoneyOff: IeVoucher
    {
        public void ProcessVoucher(IVoucher vc, IBasket bkt, IBasketVoucher bv)
        {
            if (vc.MinSpend < bkt.BasketTotal())
            {
                bv.Value = -vc.Value;
                bv.VoucherCode = vc.VoucherCode;
                bv.VoucherDescription = vc.VoucherDescription;
                bv.VoucherId = vc.VoucherId;
                bkt.AddBasketVoucher(bv);
            }
        }
    }
}
