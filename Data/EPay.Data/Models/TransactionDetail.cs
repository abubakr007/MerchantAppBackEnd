using System;
using System.Collections.Generic;

namespace EPay.Data.Models
{
    public partial class TransactionDetail
    {
        public long TrxNo { get; set; }
        public int ProviderId { get; set; }
        public string EanCode { get; set; } = null!;
        public string Currency { get; set; } = null!;
        public double FaceValue { get; set; }
        public double? TaxRate { get; set; }
        public double? TaxAmount { get; set; }
        public double? CustomerPaidAmount { get; set; }
        public double? OpenBalance { get; set; }
        public double? MerchantNetPrice { get; set; }
        public double? ClosedBalance { get; set; }
        public bool? TrxStatus { get; set; }
        public bool? ReconcilationStatus { get; set; }
        public DateTime? ReconcilationTime { get; set; }
        public bool? ReconcilationResult { get; set; }
        public string? InternalRef { get; set; }
        public long TransactionMasterId { get; set; }
        public double? Points { get; set; }
        public double? Qty { get; set; }
        public bool? IsClaimed { get; set; }
        public long? IsClaimedTrxId { get; set; }
        public bool? IsHang { get; set; }
        public string? ProductParam1 { get; set; }
        public int? WorkerId { get; set; }
        public int? ProductId { get; set; }
    }
}
