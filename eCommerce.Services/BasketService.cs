using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eCommerce.Contracts.Repos;
using eCommerce.Models;
using System.Web;

namespace eCommerce.Services
{
    public class BasketService
    {
        IRepositoryBase<Basket> baskets;
        private IRepositoryBase<Voucher> vouchers;
        private IRepositoryBase<VoucherType> voucherTypes;
        private IRepositoryBase<BasketVoucher> basketVouchers;

        public const string BasketSessionString = "eCommerceBasketSession";

        public BasketService(
            IRepositoryBase<Basket> bks,
            IRepositoryBase<Voucher> vcs,
            IRepositoryBase<VoucherType> vts,
            IRepositoryBase<BasketVoucher> bvs)
        {
            baskets = bks;
            this.vouchers = vcs;
            this.voucherTypes = vts;
            this.basketVouchers = bvs;
        }

        #region Create_New_Basket
        private Basket CreateNewBasket(HttpContextBase httpContext)
        {
            //first create a new cookie.
            HttpCookie cookie = new HttpCookie(BasketSessionString);
            //now create a new basket and set the creation date.
            Basket basket = new Basket();
            basket.date = DateTime.Now;
            basket.BasketId = Guid.NewGuid();

            //add and persist in the dabase.
            baskets.Insert(basket);
            baskets.Commit();

            //add the basket id to a cookie
            cookie.Value = basket.BasketId.ToString();
            cookie.Expires = DateTime.Now.AddDays(1);
            httpContext.Response.Cookies.Add(cookie);

            return basket;
        }
        #endregion

        #region Fetch_Basket
        public Basket FetchBasket(HttpContextBase httpContext)
        {
            HttpCookie cki = httpContext.Request.Cookies.Get(BasketSessionString);
            Basket bkt = new Basket();
            Guid bktId;

            if (cki != null)
            {
                if (Guid.TryParse(cki.Value, out bktId))
                {
                    bkt = baskets.GetById(bktId);
                }
                else
                {
                    bkt = CreateNewBasket(httpContext);
                }
            }
            else
            {
                bkt = CreateNewBasket(httpContext);
            }

            return bkt;
        }
        #endregion

        #region Add_Product_To_Basket
        public bool AddProductToBasket (HttpContextBase httpContext, int pId, int CurrQty)
        {
            bool success = true;
            Basket bkt = FetchBasket(httpContext);
            BasketItem bim = bkt.BasketItems.FirstOrDefault(i => i.ProductId == pId);

            if (bim == null)
            {
                BasketItem Item = new BasketItem()
                {
                    BasketId = bkt.BasketId,
                    ProductId = pId,
                    Quantity = CurrQty
                };
                bkt.AddBasketItem(Item);
            }
            else
            {
                bim.Quantity += CurrQty;
            }

            baskets.Commit();

            return success;
        }
        #endregion

        #region Basket_Vouchers
        public void AddBasketVoucher(string vc, HttpContextBase httpContext)
        {
            Basket bkt = FetchBasket(httpContext);
            Voucher theVoucher = vouchers.GetAll().FirstOrDefault( v => v.VoucherCode == vc );

            if(theVoucher != null)
            {
                VoucherType vt = voucherTypes.GetById(theVoucher.VoucherId);
                if (vt != null)
                {
                    BasketVoucher bv = new BasketVoucher();
                    if (vt.Type == "MoneyOff")
                    {
                        MoneyOff(theVoucher, bkt, bv);
                    }
                    if (vt.Type == "PercentOff")
                    {
                        PercentOff(theVoucher, bkt, bv);
                    }

                    baskets.Commit();
                }
            }
            else
            {
                return;
            }
        }

        public void MoneyOff(Voucher targetVoucher, Basket basket, BasketVoucher bVoucher)
        {
            decimal basketTotal = basket.BasketTotal();
            if (targetVoucher.MinSpend < basketTotal)
            {
                bVoucher.Value = targetVoucher.Value * -1;
                bVoucher.VoucherCode = targetVoucher.VoucherCode;
                bVoucher.VoucherDescription = targetVoucher.VoucherDescription;
                bVoucher.VoucherId = targetVoucher.VoucherId;
                basket.AddBasketVoucher(bVoucher);
            }
        }
        public void PercentOff(Voucher targetVoucher, Basket basket, BasketVoucher bVoucher)
        {
            if (targetVoucher.MinSpend > basket.BasketTotal())
            {
                bVoucher.Value = (targetVoucher.Value * (basket.BasketTotal() / 100)) * -1;
                bVoucher.VoucherCode = targetVoucher.VoucherCode;
                bVoucher.VoucherDescription = targetVoucher.VoucherDescription;
                bVoucher.VoucherId = targetVoucher.VoucherId;
                basket.AddBasketVoucher(bVoucher);
            }
        }

        #endregion
    }
}
