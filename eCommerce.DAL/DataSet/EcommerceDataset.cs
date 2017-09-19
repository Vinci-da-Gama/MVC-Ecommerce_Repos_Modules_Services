using eCommerce.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.DAL.DataSet
{
    public class EcommerceDataset : DbContext
    {
        /// <summary>
        /// any entity to be persisted must me delcared here.
        /// </summary>
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Basket> Baskets { get; set; }
        public DbSet<BasketItem> BasketItems { get; set; }
        public DbSet<Voucher> Vouchers { get; set; }
        public DbSet<BasketVoucher> BasketVouchers { get; set; }
        public DbSet<VoucherType> VoucherTypes { get; set; }

        public EcommerceDataset() : base("eCommerce-Connection_String")
        {
            Debug.Write(Database.Connection.ConnectionString);
        }
    }
}
