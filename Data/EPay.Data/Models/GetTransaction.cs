using System;
using System.Collections.Generic;

namespace EPay.Data.Models
{
    public partial class GetTransaction
    {
        public DateTime? Date { get; set; }
        public DateTime TransactionTime { get; set; }
        public string MerchantId { get; set; } = null!;
        public int? CashierId { get; set; }
        public string CashierName { get; set; } = null!;
        public long TransactionNo { get; set; }
        public string? ReferenceNo { get; set; }
        public string? VoucherNo { get; set; }
        public string? PaymentMode { get; set; }
        public double? TotalAmount { get; set; }
        public int? ProductId { get; set; }
        public string? ProductNameEng { get; set; }
        public int SubCategoryId { get; set; }
        public string SubCategoryName { get; set; } = null!;
        public int CategoryId { get; set; }
        public string CategoryName { get; set; } = null!;
        public double? TotalQty { get; set; }
        public double FaceValue { get; set; }
        public double? TotalPrice { get; set; }
    }
}
