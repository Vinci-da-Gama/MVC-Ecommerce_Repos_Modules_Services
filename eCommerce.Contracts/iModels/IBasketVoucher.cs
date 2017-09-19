﻿using System;

namespace eCommerce.Contracts.iModels
{
    public interface IBasketVoucher
    {
        int AppliesToProductId { get; set; }
        Guid BasketId { get; set; }
        int BasketVoucherId { get; set; }
        decimal Value { get; set; }
        string VoucherCode { get; set; }
        string VoucherDescription { get; set; }
        int VoucherId { get; set; }
        string VoucherType { get; set; }
    }
}