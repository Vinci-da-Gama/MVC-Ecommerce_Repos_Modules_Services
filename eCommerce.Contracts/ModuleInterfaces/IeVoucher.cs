using eCommerce.Contracts.iModels;

namespace eCommerce.Contracts.ModuleInterfaces
{
    public interface IeVoucher
    {
        void ProcessVoucher(IVoucher vc, IBasket bkt, IBasketVoucher bv);
    }
}