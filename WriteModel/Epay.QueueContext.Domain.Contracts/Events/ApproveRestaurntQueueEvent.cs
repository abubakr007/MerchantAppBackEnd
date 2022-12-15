using Epay.Constants;
using System;
using System.Collections.Generic;

namespace Epay.QueueContext.Domain.Contracts.Events
{
    public class ApproveRestaurntQueueEvent : NotificationEvent
    {

        public int MerchantId { get; set; }
        public string? Param1 { get; set; }
        public string? Param2 { get; set; }
        public string? Param3 { get; set; }
        public string? MobileNumber { get; set; }


        public long Id { get; set; }
        public string MerchantCode { get; set; }
        public int CreatedBy { get; set; }
        public int CashierId { get; set; }
        public DateTime CreatedOn { get; set; }
        public int PaymentMode { get; set; }
        public long? CustomerId { get; set; }
        public string? NfccardNumber { get; set; }
        public bool IsPaid { get; set; }
        public double TotalAmount { get; set; }
        public string? CouponCode { get; set; }

        public long TokenNumber { get; set; }
        public int OfflineTokenNumber { get; set; }
        public DateTime OpeningTime { get; set; }
        public DateTime? CompletionTime { get; set; }
        public long? TransactionMasterId { get; set; }
        public int QueueStatusId { get; set; }

        public int? TableId { get; set; }
        public string RequestedBy { get; set; }
        public double TotalTax { get; set; }
        public IList<QueueDetailEvent> QueueDetails { get; set; } = new List<QueueDetailEvent>();
        public override string NotificationType => NotificationTypes.QueueApproved;
    }
}
