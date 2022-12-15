using System;
using System.Collections.Generic;
using System.Linq;

namespace Epay.ReadModel.Queries.Contracts.Dto
{
    public class QueueMasterDto
    {

        public long Id { get; set; }
        public int MerchantId { get; set; }
        public int CreatedBy { get; set; }
        public int CashierId { get; set; }
        public DateTime CreatedOn { get; set; }
        public int PaymentMode { get; set; }
        public long? CustomerId { get; set; }
        public string? CustomerName { get; set; }
        public string? CustomerPhoneNumber { get; set; }
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
        public string? RequestedBy { get; set; }
        public DateTime ApprovedDateTime { get; set; }
        public string? MobileNumber { get; set; }
        public double TotalTax { get; set; }
        public double TotalDiscount { get => QueueDetails.Sum(x => x.Discount); }
        public QueueStatusDto QueueStatus { get; set; } = null!;
        public QueueRestaurantDto QueueRestaurant { get; set; } = null!;
        public ICollection<QueueDetailDto> QueueDetails { get; set; }
    }
}
