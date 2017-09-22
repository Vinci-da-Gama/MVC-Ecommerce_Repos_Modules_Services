using eCommerce.Contracts.Repos;
using eCommerce.DAL.DataSet;
using eCommerce.DAL.Repositories;
using eCommerce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using eCommerce.Services;

namespace eCommerce.WebUi.Controllers
{
    public class HomeController : Controller
    {
        IRepositoryBase<Customer> Customers;
        IRepositoryBase<Product> Products;
        IRepositoryBase<Basket> Basket;
        IRepositoryBase<Voucher> Vouchers;
        IRepositoryBase<VoucherType> VoucherTypes;
        IRepositoryBase<BasketVoucher> BasketVouchers;

        BasketService bs;

        public HomeController(IRepositoryBase<Customer> custs, IRepositoryBase<Product> pds, IRepositoryBase<Basket> bsk, IRepositoryBase<Voucher> vcs, IRepositoryBase<VoucherType> vts, IRepositoryBase<BasketVoucher> bvs)
        {
            this.Customers = custs;
            this.Products = pds;
            this.Basket = bsk;
            this.Vouchers = vcs;
            this.VoucherTypes = vts;
            this.BasketVouchers = bvs;

            bs = new BasketService(this.Basket, this.Vouchers, this.VoucherTypes, this.BasketVouchers);
        }

        public ActionResult Index()
        {
            //ProductRepository p0 = new ProductRepository(new EcommerceDataset());
            //IRepositoryBase<Customer> C0 = new CustomerRepository( new EcommerceDataset() );
            ViewBag.Title = "Home Page";
            var ProductList = Products.GetAll();

            return View(ProductList);
        }

        public ActionResult DetailsDisplay (int Pid)
        {
            Product pd = Products.GetById(Pid);
            return View(pd);
        }

        public ActionResult BasketSummary()
        {
            Basket bkt = bs.FetchBasket(this.HttpContext);
            return View(bkt);
        }

        public ActionResult AddPdToBasket(int Pid)
        {
            const int One = 1;
            bool isSuccessful = bs.AddProductToBasket(this.HttpContext, Pid, One);

            if (isSuccessful)
            {
                return RedirectToAction("BasketSummary");
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        public ActionResult AddBasketVoucher(string VoucherCodeField)
        {
            bs.AddBasketVoucher(VoucherCodeField, this.HttpContext);
            return RedirectToAction("BasketSummary");
        }
    }
}
