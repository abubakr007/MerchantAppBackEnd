using System;
using System.Collections.Generic;

namespace EPay.Data.Models
{
    public partial class QueueList
    {
        public long Id { get; set; }
        public long TokenNumber { get; set; }
        public string MerchantId { get; set; } = null!;
        public string? TerminalId { get; set; }
        public int? CashierId { get; set; }
        public string? CardNumber { get; set; }
        public string? Param1 { get; set; }
        public string Item { get; set; } = null!;
        public string Quantity { get; set; } = null!;
        public string? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string? LastModifiedBy { get; set; }
        public DateTime? LastModifiedOn { get; set; }
        public bool? Status { get; set; }
        public double? TotalAmount { get; set; }
        public string? QueueStatus { get; set; }
        public string? MobileNumber { get; set; }
        public int? QgroupId { get; set; }
        public double? EstimatedTime { get; set; }
        public bool IsPaid { get; set; }
        public string? Discount { get; set; }
        public long? CustomerId { get; set; }
        public string? CouponCode { get; set; }
        public string? Itemopenprice { get; set; }
        public string? RefNumber { get; set; }
        public double? TotalAmountWithoutDiscount { get; set; }
        public string? Param2 { get; set; }
        public string? Param3 { get; set; }
        public bool IsHang { get; set; }
        public int WorderId { get; set; }
        public int? FromAddress { get; set; }
        public int? ToAddress { get; set; }
        public long OrderId { get; set; }
        public long? QueueListMasterId { get; set; }
        public string? PaymentMode { get; set; }
        public long? TransactionMasterId { get; set; }
        public string? OnlinePaymentRef { get; set; }
        public string? CaptureRef { get; set; }

        public virtual Cashier? Cashier { get; set; }
    }
}
