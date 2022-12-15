using System;
using System.Collections.Generic;

namespace EPay.Data.Models
{
    public partial class TransactionMaster
    {
        public TransactionMaster()
        {
            QueueMasters = new HashSet<QueueMaster>();
        }

        public long Id { get; set; }
        public string? VoucherNo { get; set; }
        public double? TotalAmount { get; set; }
        public double? TotalTaxAmount { get; set; }
        public double? TotalQty { get; set; }
        public bool? Status { get; set; }
        public bool TrxStatus { get; set; }
        public DateTime TrxTime { get; set; }
        public string MerchantId { get; set; } = null!;
        public string TerminalId { get; set; } = null!;
        public int? CashierId { get; set; }
        public bool? ReconcilationStatus { get; set; }
        public DateTime? ReconcilationTime { get; set; }
        public bool? ReconcilationResult { get; set; }
        public int? BonusPoint { get; set; }
        public string? CardNo { get; set; }
        public int? BusinessTypeId { get; set; }
        public string? Param1 { get; set; }
        public double? TotalPoint { get; set; }
        public string? PaymentMode { get; set; }
        public int? TransactionTypeId { get; set; }
        public string? ContactNo { get; set; }
        public long? CustomerId { get; set; }
        public string? ClaimStatus { get; set; }
        public long? IdClaimRef { get; set; }
        public double DiscountAmount { get; set; }
        public string? QueueRefNo { get; set; }
        public string? Param2 { get; set; }
        public string? Param3 { get; set; }
        public int? WorkerId { get; set; }
        public bool? IsOffline { get; set; }
        public DateTime? ActualTrxTime { get; set; }
        public string? OfflineRefId { get; set; }
        public string? BusinessDayId { get; set; }
        public string? ShiftId { get; set; }
        public string? PaymentReference { get; set; }
        public bool? IsTaxExcluded { get; set; }

        public virtual ICollection<QueueMaster> QueueMasters { get; set; }
    }
}
