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
        //IRepositoryBase<Basket> Basket;
        IRepositoryBase<VoucherType> VoucherTypes;
        IRepositoryBase<Voucher> Vouchers;
        public AdminController(IRepositoryBase<Customer> custs, IRepositoryBase<Product> pds, IRepositoryBase<VoucherType> vts, IRepositoryBase<Voucher> vcs)
        {
            this.Customers = custs;
            this.Products = pds;
            this.VoucherTypes = vts;
            this.Vouchers = vcs;
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

        #region VoucherType_CRUD

        public ActionResult VoucherTypeList()
        {
            var VtModel = VoucherTypes.GetAll();
            return View(VtModel);
        }
        // CreateNewVoucherType
        public ActionResult CreateNewVoucherType()
        {
            VoucherType vt = new VoucherType();
            return View(vt);
        }

        [HttpPost]
        public ActionResult CreateNewVoucherType(VoucherType vt)
        {
            VoucherTypes.Insert(vt);
            VoucherTypes.Commit();
            return RedirectToAction("VoucherTypeList");
        }

        //EditVoucherType
        public ActionResult EditVoucherType(int VtId)
        {
            VoucherType VtModel = VoucherTypes.GetById(VtId);
            return View(VtModel);
        }

        [HttpPost]
        public ActionResult EditVoucherType(VoucherType vt)
        {
            VoucherTypes.Update(vt);
            VoucherTypes.Commit();
            return RedirectToAction("VoucherTypeList");
        }

        //DetailsVoucherType
        [HttpGet]
        public ActionResult DetailsVoucherType(int VtId)
        {
            var vt = VoucherTypes.GetById(VtId);
            return View(vt);
        }

        //DeleteVoucherType
        //[HttpDelete]
        public ActionResult DeleteVoucherType(int VtId)
        {
            VoucherTypes.Delete(VtId);
            VoucherTypes.Commit();
            return RedirectToAction("VoucherTypeList");
        }

        #endregion

        #region Voucher_CRUD

        public ActionResult VoucherList()
        {
            var vModel = Vouchers.GetAll();
            return View(vModel);
        }

        public ActionResult CreateNewVoucher()
        {
            Voucher vc = new Voucher();
            //These two for httpContext
            ViewBag.VoucherTypes = VoucherTypes.GetAll();
            ViewBag.Products = Products.GetAll();
            return View(vc);
        }

        [HttpPost]
        public ActionResult CreateNewVoucher(Voucher newVoucher)
        {
            Vouchers.Insert(newVoucher);
            Vouchers.Commit();
            return RedirectToAction("VoucherList");
        }

        public ActionResult EditVoucher(int Vid)
        {
            Voucher vc = Vouchers.GetById(Vid);
            return View(vc);
        }

        [HttpPost]
        public ActionResult EditVoucher(Voucher vc)
        {
            Vouchers.Update(vc);
            Vouchers.Commit();
            return RedirectToAction("VoucherList");
        }

        public ActionResult VoucherDetails(int Vid)
        {
            Voucher vc = Vouchers.GetById(Vid);
            return View(vc);
        }

        public ActionResult DeleteVoucher(int Vid)
        {
            Vouchers.Delete(Vid);
            Vouchers.Commit();
            return RedirectToAction("VoucherList");
        }

        #endregion
    }
}