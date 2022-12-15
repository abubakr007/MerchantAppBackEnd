using System;
using System.Collections.Generic;

namespace EPay.Data.Models
{
    public partial class QueueMaster
    {
        public QueueMaster()
        {
            QueueDetails = new HashSet<QueueDetail>();
        }

        public long Id { get; set; }
        public int MerchantId { get; set; }
        public int? CreatedBy { get; set; }
        public int? CashierId { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime CreatedOn { get; set; }
        public int PaymentMode { get; set; }
        public long? CustomerId { get; set; }
        public string? NfccardNumber { get; set; }
        public bool IsPaid { get; set; }
        public double TotalAmount { get; set; }
        public string? CouponCode { get; set; }
        public string? Param1 { get; set; }
        public string? Param2 { get; set; }
        public string? Param3 { get; set; }
        public long TokenNumber { get; set; }
        public int OfflineTokenNumber { get; set; }
        public DateTime OpeningTime { get; set; }
        public DateTime? CompletionTime { get; set; }
        public long? TransactionMasterId { get; set; }
        public int QueueStatusId { get; set; }
        public string? MobileNumber { get; set; }
        public string? RequestedBy { get; set; }
        public DateTime ApprovedDateTime { get; set; }
        public double TotalTax { get; set; }

        public virtual Cashier? Cashier { get; set; }
        public virtual Customer? Customer { get; set; }
        public virtual QueueStatus QueueStatus { get; set; } = null!;
        public virtual TransactionMaster? TransactionMaster { get; set; }
        public virtual QueueLaundary QueueLaundary { get; set; } = null!;
        public virtual QueueRestaurant QueueRestaurant { get; set; } = null!;
        public virtual ICollection<QueueDetail> QueueDetails { get; set; }
    }
}
