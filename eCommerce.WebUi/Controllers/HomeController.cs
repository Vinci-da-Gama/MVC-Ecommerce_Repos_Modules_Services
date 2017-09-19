using eCommerce.Contracts.Repos;
using eCommerce.DAL.DataSet;
using eCommerce.DAL.Repositories;
using eCommerce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace eCommerce.WebUi.Controllers
{
    public class HomeController : Controller
    {
        IRepositoryBase<Customer> Customers;
        IRepositoryBase<Product> Products;
        IRepositoryBase<Basket> Basket;
        public HomeController(IRepositoryBase<Customer> custs, IRepositoryBase<Product> pds, IRepositoryBase<Basket> bsk)
        {
            this.Customers = custs;
            this.Products = pds;
            this.Basket = bsk;
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
    }
}
