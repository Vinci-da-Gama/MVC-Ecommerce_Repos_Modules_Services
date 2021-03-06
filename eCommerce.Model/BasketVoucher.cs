﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eCommerce.Contracts.iModels;

namespace eCommerce.Models
{
    public class BasketVoucher : IBasketVoucher
    {
        public int BasketVoucherId { get; set; }
        public int VoucherId { get; set; }
        public Guid BasketId { get; set; }

        [MaxLength(10)]
        public string VoucherCode { get; set; }
        [MaxLength(100)]
        public string VoucherType { get; set; }
        public decimal Value { get; set; }
        [MaxLength(150)]
        public string VoucherDescription { get; set; }
        public int AppliesToProductId { get; set; }
    }
}
