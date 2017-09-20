using eCommerce.Contracts.Repos;
using eCommerce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace eCommerce.WebUi.Controllers
{
    public class AdminController : Controller
    {
        IRepositoryBase<Customer> Customers;
        IRepositoryBase<Product> Products;
        IRepositoryBase<Basket> Basket;
        public AdminController(IRepositoryBase<Customer> custs, IRepositoryBase<Product> pds, IRepositoryBase<Basket> bsk)
        {
            this.Customers = custs;
            this.Products = pds;
            this.Basket = bsk;
        }

        // GET: Admin
        public ActionResult AdminHome()
        {
            return View();
        }
        #region Product_CRUD
        public ActionResult ProductList()
        {
            var model = Products.GetAll();
            return View(model);
        }

        public ActionResult CreateNewProduct()
        {
            var model = new Product();
            return View(model);
        }

        [HttpPost]
        public ActionResult CreateNewProduct( Product pd )
        {
            Products.Insert(pd);
            Products.Commit();
            return RedirectToAction("ProductList");
        }

        public ActionResult EditProduct(int pId)
        {
            Product pd = Products.GetById(pId);
            return View(pd);
        }

        [HttpPost]
        public ActionResult EditProduct( Product pd )
        {
            Products.Update(pd);
            Products.Commit();
            return RedirectToAction("ProductList");
        }

        [HttpGet]
        public ActionResult ProductDetails(int Pid)
        {
            Product pdModel = Products.GetById(Pid);
            return View(pdModel);
        }

        //public ActionResult ProductDelete(int Pid)
        //{
        //    Product pdModel = Products.GetById(Pid);
        //    return View(pdModel);
        //}

        public ActionResult ProductDelete(int Pid)
        {
            Products.Delete(Pid);
            Products.Commit();
            return RedirectToAction("ProductList");
        }

        #endregion

        #region Voucher_CRUD



        #endregion
    }
}